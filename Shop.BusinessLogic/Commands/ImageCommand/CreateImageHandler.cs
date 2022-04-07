using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Store.BusinessLogic.Common;
using Store.DAL.Entities;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Commands.ImageCommand
{
    public class CreateImageHandler : IRequestHandler<CreateImageCommand, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<CreateImageHandler> _logger;
        private readonly string _mainPath;

        public CreateImageHandler(IStoreDbContext context, ILogger<CreateImageHandler> logger,
            IConfiguration configuration)
        {
            _logger = logger;
            _context = context;
            _mainPath = configuration["ImagesPath"];
        }

        public async Task<ResponseBase> Handle(CreateImageCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(LoggerMessages.DoneMessage("Start Handler"));
            var dto = request.Images;
            var item = await _context.Items.FindAsync(dto.ItemId);
            var images = new List<ItemImage>();

            var task = new Task(() =>
            {
                foreach (var file in dto.Files)
                {
                    var id = Guid.NewGuid();
                    var image = new ItemImage
                    {
                        Id = id, ImageFormat = _context.ImageFormats.First(x => x.Format == file.ContentType),
                        Item = item, Path = $"{_mainPath}{id}.{file.ContentType.Split("/").Last()}"
                    };
                    images.Add(image);
                    using (var stream = File.Create(image.Path))
                    {
                        file.CopyTo(stream);
                    }
                }
            });
            task.Start();
            task.Wait(cancellationToken);
            await _context.Images.AddRangeAsync(images, cancellationToken);
            _logger.LogInformation(LoggerMessages.DoneMessage("End Handler"));

            return new CreateImageResponse(images.Select(x => x.Id).ToList());
        }
    }
}
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects.Item;
using Store.DAL.Entities;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Queries.ItemQueries.GetById
{
    public class HandlerGetItemById : IRequestHandler<QueryGetItemById, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<HandlerGetItemById> _logger;
        private readonly IMapper _mapper;

        public HandlerGetItemById(IStoreDbContext context, ILogger<HandlerGetItemById> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ResponseBase> Handle(QueryGetItemById request, CancellationToken cancellationToken)
        {
            var item = await _context.Items.FindAsync(request.Id);
            var result = _mapper.Map<ItemDto>(item);
            result.Images = await LoadImagesAsync(item, cancellationToken);
            _logger.LogInformation(LoggerMessages.DoneMessage(nameof(Handle)));
            return new ResponseGetItemById(result);
        }

        private async Task<IList<FileContentResult>> LoadImagesAsync(Item item, CancellationToken cancellationToken)
        {
            var imageList = new List<FileContentResult>();
            await Task.Run(async () =>
            {
                foreach (var image in item.Images)
                {
                    var file = new FileContentResult(await File.ReadAllBytesAsync(image.Path, cancellationToken),
                        image.ImageFormat.Format);
                    imageList.Add(file);
                }
            }, cancellationToken);
            return imageList;
        }
    }
}
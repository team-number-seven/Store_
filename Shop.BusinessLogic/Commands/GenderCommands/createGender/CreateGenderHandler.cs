using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Store.BusinessLogic.Common;
using Store.DAL.Entities;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Commands.GenderCommands.CreateGender
{
    public class CreateGenderHandler : IRequestHandler<CreateGenderCommand, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<CreateGenderHandler> _logger;

        public CreateGenderHandler(IStoreDbContext context, ILogger<CreateGenderHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(CreateGenderCommand request, CancellationToken cancellationToken)
        {
            var gender = new Gender {Id = Guid.NewGuid(), Title = request.Title};
            await _context.Genders.AddAsync(gender, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation(LoggerMessages.DoneMessage(nameof(Handle)));

            return new CreateGenderResponse(gender.Id) {StatusCode = HttpStatusCode.Created};
        }
    }
}
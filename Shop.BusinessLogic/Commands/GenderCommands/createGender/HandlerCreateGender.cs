using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Store.BusinessLogic.Common;
using Store.DAL.Entities;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Commands.GenderCommands.CreateGender
{
    public class HandlerCreateGender : IRequestHandler<CommandCreateGender, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<HandlerCreateGender> _logger;

        public HandlerCreateGender(IStoreDbContext context, ILogger<HandlerCreateGender> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(CommandCreateGender request, CancellationToken cancellationToken)
        {
            var gender = new Gender {Id = Guid.NewGuid(), Title = request.Title};
            await _context.Genders.AddAsync(gender, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation(LoggerMessages.DoneMessage("Handle"));
            return new ResponseCreateGender(gender.Id);
        }
    }
}
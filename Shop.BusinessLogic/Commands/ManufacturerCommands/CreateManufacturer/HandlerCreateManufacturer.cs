using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Store.BusinessLogic.Common;
using Store.DAL.Entities;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Commands.ManufacturerCommands.CreateManufacturer
{
    public class HandlerCreateManufacturer : IRequestHandler<CommandCreateManufacturer, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<HandlerCreateManufacturer> _logger;
        private readonly IMapper _mapper;

        public HandlerCreateManufacturer(IStoreDbContext context, IMapper mapper,
            ILogger<HandlerCreateManufacturer> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(CommandCreateManufacturer request, CancellationToken cancellationToken)
        {
            var result =
                await _context.Manufacturers.AddAsync(new Manufacturer {Id = Guid.NewGuid(), Title = request.Title},
                    cancellationToken);
            _logger.LogInformation(MHFL.Done("Handle"));
            return new ResponseCreateManufacturer(result.Entity.Id);
        }
    }
}
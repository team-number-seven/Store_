using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Queries.ManufacturerQueries.GetAllManufacturer
{
    public class HandlerGetAllManufacturer : IRequestHandler<QueryGetAllManufacturer, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<HandlerGetAllManufacturer> _logger;
        private readonly IMapper _mapper;

        public HandlerGetAllManufacturer(IStoreDbContext context, ILogger<HandlerGetAllManufacturer> logger,
            IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ResponseBase> Handle(QueryGetAllManufacturer request, CancellationToken cancellationToken)
        {
            var manufacturers = await _context.Manufacturers.ToListAsync(cancellationToken);
            var response = new ResponseGetAllManufacturer(new List<ManufacturerDTO>());
            var task = new Task(() =>
            {
                foreach (var manufacturer in manufacturers)
                    response.Manufacturers.Add(_mapper.Map<ManufacturerDTO>(manufacturer));
            });
            task.Start();
            task.Wait(cancellationToken);
            _logger.LogInformation(MHFL.Done("Handler"));
            return response;
        }
    }
}
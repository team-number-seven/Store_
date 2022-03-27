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

namespace Store.BusinessLogic.Queries.ItemTypeQueries.GetAllTypeAndSubType
{
    public class HandlerGetAllTypeAndSubType : IRequestHandler<QueryGetAllTypeAndSubType, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<HandlerGetAllTypeAndSubType> _logger;
        private readonly IMapper _mapper;

        public HandlerGetAllTypeAndSubType(IStoreDbContext context, IMapper mapper,
            ILogger<HandlerGetAllTypeAndSubType> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(QueryGetAllTypeAndSubType request, CancellationToken cancellationToken)
        {
            var types = await _context.ItemTypes.Include(x => x.SubItemTypes).ToListAsync(cancellationToken);
            var response = new ResponseGetAllTypeAndSubType(new List<ItemTypeAndSubTypeDTO>());
            var task = new Task(() =>
            {
                foreach (var type in types)
                    response.TypeAndSubItem.Add(_mapper.Map<ItemTypeAndSubTypeDTO>(type));
            });
            task.Start();
            task.Wait(cancellationToken);
            _logger.LogInformation(MHFL.Done("Handler"));
            return response;
        }
    }
}
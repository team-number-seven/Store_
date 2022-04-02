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

namespace Store.BusinessLogic.Queries.AgeTypeItemQueries.GetAllAgeTypeItem
{
    public class HandlerGetAllAgeTypeItem : IRequestHandler<QueryGetAllAgeTypeItem, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<HandlerGetAllAgeTypeItem> _logger;
        private readonly IMapper _mapper;

        public HandlerGetAllAgeTypeItem(IStoreDbContext context, IMapper mapper,
            ILogger<HandlerGetAllAgeTypeItem> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(QueryGetAllAgeTypeItem request, CancellationToken cancellationToken)
        {
            var ageItemTypes = await _context.AgeTypes.ToListAsync(cancellationToken);
            var response = new ResponseGetAllAgeTypeItem(new List<AgeTypeItemDTO>());
            var task = new Task(() =>
            {
                foreach (var type in ageItemTypes)
                    response.Types.Add(_mapper.Map<AgeTypeItemDTO>(type));
            });
            task.Start(); task.Wait(cancellationToken);
            _logger.LogInformation(MHFL.Done("Handle"));
            return response;
        }
    }
}
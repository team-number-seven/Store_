using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Queries.SizeTypeItemQueries.GetAllSizeTypeItems
{
    public class HandlerGetAllSizesTypeItems: IRequestHandler<QueryGetAllSizesTypeItems,ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<HandlerGetAllSizesTypeItems> _logger;

        public HandlerGetAllSizesTypeItems(IStoreDbContext context,IMapper mapper,ILogger<HandlerGetAllSizesTypeItems> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<ResponseBase> Handle(QueryGetAllSizesTypeItems request, CancellationToken cancellationToken)
        {
            var sizes = await _context.SizeTypeItems.ToListAsync(cancellationToken);
            var response = new ResponseGetAllSizesTypeItems(new List<SizeTypeItemDTO>());
            var task = new Task(() =>
            {
                foreach (var size in sizes)
                    response.Sizes.Add(_mapper.Map<SizeTypeItemDTO>(size));
            });
            task.Start();
            task.Wait(cancellationToken);
            _logger.LogInformation(MHFL.Done("Handle"));
            return response;
        }
    }
}

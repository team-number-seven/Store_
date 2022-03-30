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

namespace Store.BusinessLogic.Queries.BrandQueries.GetAllBrands
{
    public class HandlerGetAllBrands : IRequestHandler<QueryGetAllBrands, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<HandlerGetAllBrands> _logger;
        private readonly IMapper _mapper;

        public HandlerGetAllBrands(IStoreDbContext context, ILogger<HandlerGetAllBrands> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ResponseBase> Handle(QueryGetAllBrands request, CancellationToken cancellationToken)
        {
            var brands = await _context.Brands.ToListAsync(cancellationToken);
            var response = new ResponseGetAllBrands(new List<BrandDTO>());
            var task = new Task(() =>
            {
                foreach (var brand in brands)
                    response.Brands.Add(_mapper.Map<BrandDTO>(brand));
            });
            task.Start();
            task.Wait(cancellationToken);
            _logger.LogInformation(MHFL.Done("Handle"));
            return response;
        }
    }
}
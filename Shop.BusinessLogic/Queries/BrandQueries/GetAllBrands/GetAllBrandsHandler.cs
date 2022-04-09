using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects.Brand;
using Store.DAL.Entities;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Queries.BrandQueries.GetAllBrands
{
    public class GetAllBrandsHandler : IRequestHandler<GetAllBrandsQuery, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<GetAllBrandsHandler> _logger;
        private readonly IMapper _mapper;

        public GetAllBrandsHandler(IStoreDbContext context, ILogger<GetAllBrandsHandler> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ResponseBase> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
        {
            var brands = await _context.Brands.ToListAsync(cancellationToken);
            var brandsDto = await CreateBrandsDtoAsync(brands, cancellationToken);
            _logger.LogInformation(LoggerMessages.DoneMessage(nameof(Handle)));

            return new GetAllBrandsResponse(brandsDto);
        }

        private async Task<List<BrandDto>> CreateBrandsDtoAsync(IReadOnlyCollection<Brand> brands,
            CancellationToken cancellationToken)
        {
            var brandsDto = new List<BrandDto>();
            await Task.Run(() => { brandsDto.AddRange(brands.Select(brand => _mapper.Map<BrandDto>(brand)).OrderBy(x=>x.Title)); },
                cancellationToken);

            return brandsDto;
        }
    }
}
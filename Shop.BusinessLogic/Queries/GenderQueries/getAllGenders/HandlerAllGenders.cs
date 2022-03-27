using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects;
using Store.DAL.Entities;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Queries.GenderQueries.GetAllGenders
{
    public class HandlerAllGenders : IRequestHandler<QueryAllGenders, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<HandlerAllGenders> _logger;
        private readonly IMapper _mapper;

        public HandlerAllGenders(IStoreDbContext context, ILogger<HandlerAllGenders> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ResponseBase> Handle(QueryAllGenders request, CancellationToken cancellationToken)
        {
            IList<Gender> genders = await _context.Genders.ToListAsync(cancellationToken);
            var response = new ResponseAllGenders(new List<GenderDTO>());
            var task = new Task(() =>
            {
                foreach (var c in genders)
                    response.Genders.Add(_mapper.Map<GenderDTO>(c));
            });

            task.Start();
            _logger.LogInformation(MHFL.Done("Handle"));
            task.Wait(cancellationToken);

            return response;
        }
    }
}
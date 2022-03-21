using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Store.BusinessLogic.Common;
using Store.DAL.Entities;
using Store.DAL.Interfaces;
using static Store.BusinessLogic.Common.DTOS.EntitiesDTOS;


namespace Store.BusinessLogic.Queries.GenderQueries.getAllGenders
{
    public static partial class GetAllGenders
    {
        public class Handler : IRequestHandler<Query, ResponseBase>
        {
            private readonly IStoreDbContext _context;
            private readonly ILogger<Handler> _logger;

            public Handler(IStoreDbContext context, ILogger<Handler> logger)
            {
                _context = context;
                _logger = logger;
            }

            public async Task<ResponseBase> Handle(Query request, CancellationToken cancellationToken)
            {
                IList<Gender> genders = await _context.Genders.ToListAsync(cancellationToken);
                var response = new Response(new List<GenderDTO>());

                if (genders is not null)
                    Parallel.ForEach(genders, g => response.Genders.Add(new GenderDTO(g.Id, g.Title)));

                _logger.LogInformation($"[{DateTime.Now}]Get genders is successful for {typeof(Handler)}");

                return response;
            }
        }
    }
}
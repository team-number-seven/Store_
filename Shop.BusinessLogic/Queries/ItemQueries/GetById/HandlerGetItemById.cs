using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects;
using Store.BusinessLogic.Queries.GenderQueries.GetGenderById;
using Store.DAL;
using Store.DAL.Entities;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Queries.ItemQueries.GetById
{
    public class HandlerGetItemById : IRequestHandler<QueryGetItemById, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<HandlerGetItemById> _logger;
        private readonly IMapper _mapper;

        public HandlerGetItemById(IStoreDbContext context, ILogger<HandlerGetItemById> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ResponseBase> Handle(QueryGetItemById request, CancellationToken cancellationToken)
        {
            var item = await _context.Items.FindAsync(request.Id);
            var result = _mapper.Map<ItemDTO>(item);
            _logger.LogInformation(MHFL.Done("Handler"));
            return new ResponseGetItemById(result);
        }

    }
}
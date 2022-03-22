﻿using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects;
using Store.DAL.Interfaces;

namespace Store.BusinessLogic.Queries.GenderQueries.GetGenderById
{
    public class HandlerGenderById : IRequestHandler<QueryGenderById, ResponseBase>
    {
        private readonly IStoreDbContext _context;
        private readonly ILogger<HandlerGenderById> _logger;
        private readonly IMapper _mapper;

        public HandlerGenderById(IStoreDbContext context, IMapper mapper, ILogger<HandlerGenderById> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseBase> Handle(QueryGenderById request, CancellationToken cancellationToken)
        {
            var gender = await _context.Genders.FindAsync(request.Id);
            if (gender is null)
            {
                _logger.LogInformation($"${DateTime.Now} Gender by id not found");
                return new ResponseBase("Gender not found", HttpStatusCode.NotFound);
            }

            _logger.LogInformation($"${DateTime.Now} Gender by id found successfully");
            return new ResponseGenderById(_mapper.Map<GenderDTO>(gender));
        }
    }
}
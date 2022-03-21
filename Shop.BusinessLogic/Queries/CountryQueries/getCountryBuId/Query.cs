﻿using MediatR;
using Store.BusinessLogic.Common;
using System;

namespace Store.BusinessLogic.Queries.CountryQueries.getCountryBuId
{
    public static partial class GetCountryById
    {
        public record Query(Guid Id) : IRequest<ResponseBase>;
    }
}

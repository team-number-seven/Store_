﻿using System;
using MediatR;
using Store.BusinessLogic.Common;

namespace Store.BusinessLogic.Queries.CountryQueries.GetCountryById
{
    public record QueryGetCountryById(string Id) : IRequest<ResponseBase>;
}
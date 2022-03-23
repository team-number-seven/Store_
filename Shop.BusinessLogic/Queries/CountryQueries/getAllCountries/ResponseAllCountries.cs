﻿using System.Collections.Generic;
using Store.BusinessLogic.Common;
using Store.BusinessLogic.Common.DataTransferObjects;

namespace Store.BusinessLogic.Queries.CountryQueries.GetAllCountries
{
    public record ResponseAllCountries(IList<CountryDTO> Countries) : ResponseBase;
}
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Store.BusinessLogic.Commands.ItemCommands.createItem
{
    public static partial class CreateItem
    {
        public record Command(string Title, string Description, Guid GenderId, Guid BrandId, Guid ColorId,
            Guid CountryId, Guid AgeTypeId, Guid ManufacturerId, IList<Guid> TypeItemsId, IFormFile MainImage,
            IList<IFormFile> Images);
    }
}
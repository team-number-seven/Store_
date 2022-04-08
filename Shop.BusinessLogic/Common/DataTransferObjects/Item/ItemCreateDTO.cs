using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Store.BusinessLogic.Common.DataTransferObjects.Item
{
    public class ItemCreateDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Price { get; set; }

        public string ArticleNumber { get; set; }

        public Guid BrandId { get; set; }

        public Guid ColorId { get; set; }

        public Guid AgeTypeItemId { get; set; }

        public Guid SeasonItemId { get; set; }

        public Guid GenderId { get; set; }

        public Guid ItemTypeId { get; set; }

        public Guid SubItemTypeId { get; set; }
        public IList<SizeCountItemCreateDto> SizeCountItemsCreateDto { get; set; }
        [FromForm]public SizeCountItemCreateDto SizeCountItemsCreate { get; set; }
        
        public IList<IFormFile> Files { get; set; }
    }
}
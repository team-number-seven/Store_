using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Store.BusinessLogic.Common.DataTransferObjects.Item
{
    public class CreateItemDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Price { get; set; }

        public string ArticleNumber { get; set; }

        public Guid BrandId { get; set; }

        public Guid ColorId { get; set; }

        public Guid AgeTypeId { get; set; }

        public Guid SeasonId { get; set; }

        public Guid GenderId { get; set; }

        public Guid ItemTypeId { get; set; }

        public Guid SubTypeId { get; set; }

        public IList<CreateNumberOfSizeDto> CreateNumberOfSizesDto { get; set; }

        public IFormFileCollection Files { get; set; }
    }
}
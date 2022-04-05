using System;
using Microsoft.AspNetCore.Http;

namespace Store.BusinessLogic.Common.DataTransferObjects
{
    public class ImageCreateDto
    {
        public IFormFileCollection Files { get; set; }
        public Guid ItemId { get; set; }
    }
}
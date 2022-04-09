using System;
using Microsoft.AspNetCore.Http;

namespace Store.BusinessLogic.Common.DataTransferObjects.Image
{
    public class CreateImageDto
    {
        public IFormFileCollection Files { get; set; }
        public Guid ItemId { get; set; }
    }
}
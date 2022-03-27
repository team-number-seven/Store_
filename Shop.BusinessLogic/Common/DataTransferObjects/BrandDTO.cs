using Microsoft.AspNetCore.Http;

namespace Store.BusinessLogic.Common.DataTransferObjects
{
    public class BrandDTO
    {
        public IFormFile Logo { get; set; }
        public string Title { get; set; }
    }
}
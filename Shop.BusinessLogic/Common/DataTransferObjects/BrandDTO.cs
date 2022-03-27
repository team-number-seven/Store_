using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Store.BusinessLogic.Common.DataTransferObjects
{
    public class BrandDTO
    {
        public IFormFile Logo { get; set; }
        public string Title { get; set; }
    }
}

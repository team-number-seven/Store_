using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace Store.BusinessLogic.Common.DataTransferObjects
{
    public class ImageCreateDTO
    {
        public IFormFileCollection Files { get; set; }
        public Guid ItemId { get; set; }
    }
}

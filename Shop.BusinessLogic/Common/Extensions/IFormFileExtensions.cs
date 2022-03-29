using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Store.BusinessLogic.Common.Extensions
{
    public static class IFormFileExtensions
    {
        public static string GetImageFormat(this IFormFile file)
            =>"." + file.ContentType.Split("/").Last();
        
    }
}

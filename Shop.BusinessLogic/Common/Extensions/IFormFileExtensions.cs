using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Store.BusinessLogic.Common.Extensions
{
    public static class IFormFileExtensions
    {
        public static string GetImageFormat(this IFormFile file)
        {
            return "." + file.ContentType.Split("/").Last();
        }
    }
}
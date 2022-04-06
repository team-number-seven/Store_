using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BusinessLogic.Common
{
    public class UrlDto
    {
        public string Action { get; set; }
        public string Controller { get; set; }
        public string Protocol { get; set; }
        public string Host { get; set; }
    }
}

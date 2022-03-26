using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Store.BusinessLogic.Common
{
    public static class MHFL//MessageHelperForLogger)))
    {
        public static string Time => DateTime.Now.ToString("G");
        public static string Done(string type,string code) => $"[{Time}]{type} executed with the code {code}";
    }
}

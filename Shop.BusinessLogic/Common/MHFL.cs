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
        public static string Time => $"[{DateTime.Now:G}]";
        public static string Done(string methodName) => $"{Time}The {methodName} method done";
        public static string Done(string methodName,string id) => $"{Time}The {methodName} method done with userId[{id}]";
        public static string ObjectIsNullOrEmptyMessage => "The object cannot be null";
        public static string ObjectExists(string nameObject) => $"The {nameObject} already exists";
    }
}

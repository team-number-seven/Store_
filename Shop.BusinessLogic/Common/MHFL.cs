using System;

namespace Store.BusinessLogic.Common
{
    public static class MHFL //MessageHelperForLogger)))
    {
        public static string Time => $"[{DateTime.Now:G}]";
        public static string ObjectIsNullOrEmptyMessage => "The object cannot be null";

        public static string NameObjectIsNullOrEmptyMessage(string Name)
        {
            return $"The {Name} cannot be null";
        }

        public static string Done(string methodName)
        {
            return $"{Time}The {methodName} method done";
        }

        public static string Done(string methodName, string id)
        {
            return $"{Time}The {methodName} method done with userId[{id}]";
        }

        public static string ObjectExists(string nameObject)
        {
            return $"The {nameObject} already exists";
        }

        public static string NotFount(string name)
        {
            return $"The {name} not found";
        }
    }
}
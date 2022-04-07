using System;

namespace Store.BusinessLogic.Common
{
    // Good practice
    public static class LoggerMessages //MessageHelperForLogger)))
    {
        public static string Time => $"[{DateTime.Now:G}]";
        public static string ObjectIsNullOrEmptyMessage => "The object cannot be null";

        public static string ObjectPropertyIsNullOrEmptyMessage(string Name)
        {
            return $"The {Name} cannot be null";
        }

        public static string DoneMessage(string methodName)
        {
            return $"{Time}The {methodName} method done";
        }

        public static string DoneMessage(string methodName, string id)
        {
            return $"{Time}The {methodName} method done with userId[{id}]";
        }

        public static string ObjectExistsMessage(string nameObject)
        {
            return $"The {nameObject} already exists";
        }

        public static string NotFoundMessage(string name)
        {
            return $"The {name} not found";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCRM.App.Helpers
{
    public class Parameters
    {
        public class ApiContentType
        {
            public static string XWWWForm = "application/x-www-form-urlencoded";
            public static string Json = "application/json";
            public static string MultipartForm = "multipart/form-data";
        }

        public class PageView
        {
            public static string Home = "Home";
            public static string ProductPage = "ProductPage";
            public static string CreateProduct = "CreateProduct";

            public static string EmployeePage = "EmployeePage";
            public static string CustomerPage = "EmployeePage";
        }
        public class ApiParameter
        {
            public string Key;
            public string Value;
        }

        public static class MediatorMessages
        {
            public const string Message1 = "Message1";
        }
    }
}

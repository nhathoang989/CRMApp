using Newtonsoft.Json.Linq;
using System.Linq;
using HCRM.App.Framework;
using Newtonsoft.Json;
using System.Web;
using System;
using System.IO;
using System.Text.RegularExpressions;
using HCRM.App.Repositories;
using FirstFloor.ModernUI.Windows.Controls;

namespace HCRM.App.Ultilities
{
    class common
    {
        public static bool ConfirmDialog(string _Message, string _Title)
        {
            var dlg = new ModernDialog
            {
                Title = _Title,
                Content = _Message,
                Width = 300
            };
            dlg.Buttons = new[] { dlg.OkButton, dlg.CancelButton };
            dlg.ShowDialog();
            return dlg.DialogResult.HasValue && dlg.DialogResult.Value;
        }
        public static string CombinePath(string[] paths) {
            return Path.Combine(paths);
        }
        public static string FormatPrice(string strPrice) {
            var arr = strPrice.Trim(new char[] { ',' });
            string s1 = strPrice.Replace(",", string.Empty);
            Regex rgx = new Regex("(\\d+)(\\d{3})");
            while (rgx.IsMatch(s1))
            {
                s1 = rgx.Replace(s1, "$1" + "," + "$2");
            }
            return s1;
        }
        public static double ReversePrice(string formatedPrice) {
            return double.Parse(formatedPrice.Replace(",", string.Empty));
        }
        public static string getFullFilePath(string filePath) {
            if (!string.IsNullOrEmpty(filePath))
            {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath);
            }
            return "";
        }
        public static string getUploadFolder(string type)
        {
            string fileFolder = "Files";
            switch (type.ToLower())
            {
                case "employee":
                    fileFolder = Path.Combine(fileFolder,"Employee");
                    break;
                case "product":
                    fileFolder = Path.Combine(fileFolder, "Product");
                    break;
                case "customer":
                    fileFolder = Path.Combine(fileFolder, "Customer");
                    break;
                default:
                    fileFolder = Path.Combine(fileFolder, "Default");
                    break;
            }
            string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @fileFolder);
            if (!System.IO.Directory.Exists(fullPath))
                System.IO.Directory.CreateDirectory(fullPath);
            return fileFolder;
        }

        public static string SaveFile(string folderType, FileInfo fileInfo)
        {
            var path = getUploadFolder(folderType);
            var filePath = Path.Combine(path, fileInfo.Name);
            var fileStream = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @filePath), FileMode.Create, FileAccess.Write);
            var stream = fileInfo.OpenRead();
            stream.CopyTo(fileStream);
            stream.Dispose();
            fileStream.Dispose();
            return filePath;
        }

        public static void changePageView(string pageName) {
            var main = ApplicationViewModel.GetInstance();
            if (main!=null)
            {
                main.CurrentPageViewModel = MenuRepo.GetPageView(pageName).Model;
            }
        }       

        public static void showLoading(bool isBusy)
        {
            var main = ApplicationViewModel.GetInstance();
            if (main!=null)
            {
                main.IsBusy = isBusy;
            }
        }



        #region JSON Helpers

        public static T ParseObject<T>(string json) {
            using (var sr = new System.IO.StringReader(json))
            using (var jr = new JsonTextReader(sr))
            {
                var js = new JsonSerializer();
                var result = js.Deserialize<T>(jr);
                return result;
            }
        }
        /*
         * [{"name":"e1","data":[{"a":""},{"b":""}]}]
        */
        public static JObject getJObject(string name, JArray lstObj)
        {
            foreach (JObject obj in lstObj)
            {
                if (obj["name"].ToString() == name)
                {
                    return obj;
                }
            }
            return null;
        }

        public static JArray sortJArray(string sortBy, JArray array) {
            return new JArray(array.OrderBy(obj => (string)obj[sortBy]));
        }
        #endregion
    }
}

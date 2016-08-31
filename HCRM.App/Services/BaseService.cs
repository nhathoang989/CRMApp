using HCRM.App.Helpers;
using HCRM.App.Ultilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCRM.App.Services
{
    public class BaseServices<T> where T : class 
    {
        public string _serviceURL { get; set; }
        public string _modelName { get; set; }
        public BaseServices(string serviceURL, string modelName)
        {
            _serviceURL = serviceURL;
            _modelName = modelName;
        }

        public async Task<bool> CreateOrEditModel(T Model)
        {
            return false;
            //var rsp = await ApiHelper.postApi<T>(Model, _serviceURL+ "CreateOrEdit"+ _modelName); // "api /Model/CreateOrEditModel");
            //if (rsp.StatusCode == System.Net.HttpStatusCode.OK)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}

        }

        public async Task<T> GetModel(long ModelID)
        {
            var rsp = await ApiHelper.getApi(Helpers.Parameters.ApiContentType.XWWWForm, _serviceURL + "Get" + _modelName + ModelID, new List<Helpers.Parameters.ApiParameter>()); // "api/Model/GetModel/" + ModelID, new List<Helpers.Parameters.ApiParameter>());
            return common.ParseObject<T>(rsp.Content);
        }

        public async Task<List<T>> GetListModel()
        {
            var rsp = await ApiHelper.getApi<List<T>>(Helpers.Parameters.ApiContentType.XWWWForm, _serviceURL + "GetAll" + _modelName, new List<Helpers.Parameters.ApiParameter>()); // "api/Model/GetAllModels", new List<Helpers.Parameters.ApiParameter>());
            return common.ParseObject<List<T>>(rsp.Content);
        }

        public async Task<List<T>> SearchModels(string keyword)
        {
            var rsp = await ApiHelper.getApi<List<T>>(Helpers.Parameters.ApiContentType.XWWWForm, _serviceURL + "Search" + _modelName, new List<Helpers.Parameters.ApiParameter>());// "api/Model/SearchModels/" + keyword, new List<Helpers.Parameters.ApiParameter>());
            return common.ParseObject<List<T>>(rsp.Content);
        }

    }
}

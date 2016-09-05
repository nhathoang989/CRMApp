using System.Collections.Generic;
using System.Threading.Tasks;
using HCRM.App.Ultilities;
using System.IO;
using HCRM.App.Helpers;
using RestSharp;
using System;
using System.Reflection;

namespace HCRM.App.Repositories
{
    public class BaseRepo<TModel, TView> where TModel : new() where TView: new ()
    {
        protected string ModelName { get; set; }
        public ApiURLRepo UrlRepo { get; set; }
        public BaseRepo(string baseApiURL, string modelName)
        {
            ModelName = modelName;
            UrlRepo = new ApiURLRepo(baseApiURL, modelName);
        }
        public BaseRepo()
        {
            ModelName = "Default";
        }
        public string UploadFile(FileInfo file) {
            var filePath = "";
            if (file != null)
            {
                filePath = common.SaveFile(ModelName, file);
            }
            return filePath;
        }        

        public async Task<IRestResponse> SaveModel(TModel model)
        {
            string apiURL = UrlRepo.SaveURL;
            var rsp = await ApiHelper.postApi<TModel>(model, apiURL);
            if (rsp.StatusCode == System.Net.HttpStatusCode.OK)
            {
                ApiHelper.Alert("Kết quả", "Thành công");
            }
            else {
                ApiHelper.Alert("Kết quả", "Thất bại");
            }
            return rsp;
        }
                
        public async Task<IRestResponse> RemoveModel(TModel model)
        {
            string apiURL = UrlRepo.RemoveURL;
            var rsp = await ApiHelper.postApi<TModel>(model, apiURL);
            return rsp;
        }

        public async Task<TView> GetSingleModelBy(object param)
        {
            string apiURL = Path.Combine(UrlRepo.GetSingleURL, param.ToString());
            var rsp = await ApiHelper.getApi<TModel>(Helpers.Parameters.ApiContentType.XWWWForm, apiURL, new List<Helpers.Parameters.ApiParameter>());

            var model = common.ParseObject<TModel>(rsp.Content);

            Type classType = typeof(TView);
            ConstructorInfo classConstructor = classType.GetConstructor(new Type[] { model.GetType() });
            TView vm = (TView)classConstructor.Invoke(new object[] { model });

            return vm;
        }

        public async Task<TView> GetSingleModelBy(int param)
        {
            string apiURL = Path.Combine(UrlRepo.GetSingleURL, param.ToString());
            var rsp = await ApiHelper.getApi<TModel>(Helpers.Parameters.ApiContentType.XWWWForm, apiURL, new List<Helpers.Parameters.ApiParameter>());
            var model = common.ParseObject<TModel>(rsp.Content);
            Type classType = typeof(TView);
            ConstructorInfo classConstructor = classType.GetConstructor(new Type[] { model.GetType() });
            TView vm = (TView)classConstructor.Invoke(new object[] { model });
            return vm;
        }

        public async Task<List<TView>> GetModelList(int? pageIndex = null, int? pageSize = null)
        {
            string apiURL = Path.Combine(UrlRepo.GetListURL, (pageIndex.HasValue ? pageIndex.Value.ToString() : ""), (pageSize.HasValue ? pageSize.Value.ToString() : ""));
            var rsp = await ApiHelper.getApi<List<TModel>>(Helpers.Parameters.ApiContentType.XWWWForm, UrlRepo.GetListURL, new List<Helpers.Parameters.ApiParameter>());
            var lstModel = common.ParseObject<List<TModel>>(rsp.Content);
            List<TView> lstViewModel = new List<TView>();
            if (rsp.StatusCode== System.Net.HttpStatusCode.OK)
            {
                foreach (var model in lstModel)
                {
                    Type classType = typeof(TView);
                    ConstructorInfo classConstructor = classType.GetConstructor(new Type[] { model.GetType() });
                    TView vm = (TView)classConstructor.Invoke(new object[] { model });

                    lstViewModel.Add(vm);
                }
            }
            
            return lstViewModel;
        }

        public async Task<List<TModel>> GetModelListBy(object param, int? pageIndex = null, int? pageSize = null)
        {
            string apiURL = Path.Combine(UrlRepo.GetListURL, param.ToString(), (pageIndex.HasValue ? pageIndex.Value.ToString() : ""), (pageSize.HasValue ? pageSize.Value.ToString() : ""));
            var rsp = await ApiHelper.getApi<List<TModel>>(Helpers.Parameters.ApiContentType.XWWWForm, apiURL, new List<Helpers.Parameters.ApiParameter>());
            return common.ParseObject<List<TModel>>(rsp.Content);
        }

    }
}

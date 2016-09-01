using HCRM.WarehouseApp.ViewModels;
using HCRM.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using HCRM.WarehouseApp.Ultilities;
using System.IO;
using HCRM.WarehouseApp.ViewModels.ElementViewModels;
using HCRM.WarehouseApp.Helpers;
using RestSharp;

namespace HCRM.WarehouseApp.Repositories
{
    public class ProductRepo:BaseRepo<CRM_Product,ProductViewModel>
    {
        private static ProductRepo _instance;

        public ProductRepo() : base("api/Product", "Product")
        {
        }

        public static ProductRepo Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ProductRepo();
                }
                return _instance;
            }
        }

        //public async Task<IRestResponse> CreateOrEditProduct(CRM_Product Product, FileInfo avatar) {
        //    if (avatar!=null)
        //    {
        //        Product.Image = common.SaveFile(ModelName, avatar);
        //    }            
        //    var rsp = await ApiHelper.postApi<CRM_Product>(Product, "api/Product/CreateOrEditProduct");
        //    return rsp;
        //}

        //public async Task<CRM_Product> GetProduct(long ProductID) {
        //    string apiURL = Path.Combine("api/Product/GetProduct", ProductID.ToString());
        //    var rsp = await ApiHelper.getApi<CRM_Product>(Helpers.Parameters.ApiContentType.XWWWForm, apiURL, new List<Helpers.Parameters.ApiParameter>());
        //    CRM_Product model = rsp.Data;
        //    return model;
        //}

        //public async Task<CRM_Product> GetProductByCode(string code)
        //{
        //    string apiURL = Path.Combine("api/Product/GetProductByCode", code);
        //    var rsp = await ApiHelper.getApi<CRM_Product>(Helpers.Parameters.ApiContentType.XWWWForm, apiURL, new List<Helpers.Parameters.ApiParameter>());            
        //    return rsp.Data;
        //}

        //public async Task<List<ProductViewModel>> GetProductList(int? pageIndex = null, int? pageSize = null)
        //{
        //    string apiURL = Path.Combine("api/Product/GetProductList", (pageIndex.HasValue?pageIndex.Value.ToString():""), (pageSize.HasValue ? pageSize.Value.ToString() : ""));
        //    var rsp = await ApiHelper.getApi<List<CRM_Product>>(Helpers.Parameters.ApiContentType.XWWWForm, apiURL, new List<Helpers.Parameters.ApiParameter>());
        //    var lstModel = common.ParseObject<List<CRM_Product>>(rsp.Content);
        //    List<ProductViewModel> lstResult = new List<ProductViewModel>();
        //    foreach (var model in lstModel)
        //    {
        //        ProductViewModel vm = new ProductViewModel(model);
        //        lstResult.Add(vm);
        //    }
        //    return lstResult;
        //}

        //public async Task<List<ProductViewModel>> SearchProducts(string keyword)
        //{
        //    string apiURL = Path.Combine("api/Product/SearchProducts", keyword);
        //    var rsp = await ApiHelper.getApi<List<CRM_Product>>(Helpers.Parameters.ApiContentType.XWWWForm, apiURL, new List<Helpers.Parameters.ApiParameter>());
        //    var lstModel = common.ParseObject<List<CRM_Product>>(rsp.Content);
        //    List<ProductViewModel> lstResult = new List<ProductViewModel>();
        //    foreach (var model in lstModel)
        //    {
        //        ProductViewModel vm = new ProductViewModel(model);
        //        lstResult.Add(vm);
        //    }
        //    return lstResult;
        //}       

    }
}

using HCRM.WarehouseApp.ViewModels;
using HCRM.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HCRM.WarehouseApp.Helpers
{
    public class ProductHelperbk
    {
        public static async Task<bool> CreateOrEditProduct(CRM_Product product) {
            var rsp = await ApiHelper.postApi<CRM_Product>(product, "api/Product/CreateOrEditProduct");
            if (rsp.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static async Task<ProductViewModel> GetProduct(long productID) {
            var rsp = await ApiHelper.getApi<CRM_Product>(Helpers.Parameters.ApiContentType.XWWWForm, "api/Product/GetProduct/" + productID, new List<Helpers.Parameters.ApiParameter>());
            CRM_Product p = rsp.Data;
            return ModelToView(p);
        }

        public static async Task<CRM_Product> GetProductByCode(string code)
        {
            var rsp = await ApiHelper.getApi<CRM_Product>(Helpers.Parameters.ApiContentType.XWWWForm, "api/Product/GetProductByCode/" + code, new List<Helpers.Parameters.ApiParameter>());            
            return rsp.Data;
        }

        public static async Task<List<CRM_Product>> GetListProduct()
        {
            var rsp = await ApiHelper.getApi<List<CRM_Product>>(Helpers.Parameters.ApiContentType.XWWWForm, "api/Product/GetAllProducts", new List<Helpers.Parameters.ApiParameter>());
            List<CRM_Product> products = rsp.Data;
            //List<ProductViewModel> lstResult = new List<ProductViewModel>();
            //foreach (var product in products)
            //{
            //    lstResult.Add(ModelToView(product));
            //}            
            return products;
        }

        public static async Task<List<CRM_Product>> SearchProducts(string keyword)
        {
            var rsp = await ApiHelper.getApi<List<CRM_Product>>(Helpers.Parameters.ApiContentType.XWWWForm, "api/Product/SearchProducts/" + keyword, new List<Helpers.Parameters.ApiParameter>());
            List<CRM_Product> products = rsp.Data;
            List<ProductViewModel> lstResult = new List<ProductViewModel>();
            //foreach (var product in products)
            //{
            //    lstResult.Add(ModelToView(product));
            //}
            return products;
        }

        public static ProductViewModel ModelToView(CRM_Product product)
        {
            return (product == null)? null: new ProductViewModel()
            {
                ProductID = product.ProductID,
                Code = product.Code,
                CountRemain= product.CountRemain,
                CountImported = product.CountImported,
                CountSaled = product.CountSaled,
                Title = product.Title,
                DealPrice = product.DealPrice,
                NormalPrice = product.NormalPrice,
                SubImages = product.SubImages,
                Description = product.Description,
                Image = product.Image,
                Source = product.Source,
                IsVisible = product.IsVisible,
                IsDeleted = product.IsDeleted,
                CreatedBy = product.CreatedBy,
                CreatedDate = product.CreatedDate,
                DisplayOrder = product.DisplayOrder
            };
        }

    }
}

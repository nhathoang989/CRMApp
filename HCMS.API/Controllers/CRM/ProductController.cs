using System.Web.Http;
using HCRM.Data;
using HCRM.DAL.CRM;

namespace HCMS.API.Controllers.CRM
{
    [RoutePrefix("api/Product")]
    public class ProductController : BaseCRMController<CRM_Product>
    {
        string errorMsg = "";

        [HttpGet]
        [Route("SearchModelList/{keyword}")]
        public IHttpActionResult SearchProducts(string keyword)
        {
            var lstProduct = ProductDAL.Instance.SearchProductList(keyword);
            return Ok(lstProduct);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("GetModelList/{pageIndex:int?}/{pageSize:int?}")]
        public IHttpActionResult GetProductList(int? pageIndex = null, int? pageSize = null)
        {
            string direction = "desc";
            var lstProduct = ProductDAL.Instance.GetModelList(e => e.CreatedDate, direction, pageIndex, pageSize);
            return Ok(lstProduct);

        }

        [AllowAnonymous]
        [HttpPost]
        [Route("RemoveModel")]
        public IHttpActionResult RemoveProduct([FromBody]CRM_Product model)
        {
            return RemoveModel(model);

        }
        [Route("GetSingleModel/{id}")]
        public IHttpActionResult GetProduct(int id)
        {
            var Product = ProductDAL.Instance.GetSingleModel(e => e.ProductID == id);           
            return NotFound();

        }

        [AllowAnonymous]
        [HttpPost]
        [Route("SaveModel")]
        public IHttpActionResult SaveProduct([FromBody]CRM_Product model)
        {
            return SaveModel(model);
        }
    }
}
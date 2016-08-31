using System.Collections.Generic;
using System.Web.Http;

using HCMS.API.DALs.CRM;
using HCRM.Data;

namespace HCMS.API.Controllers
{
    [RoutePrefix("api/Product")]    
    public class ProductControllerbk : BaseApiController
    {
        string errorMsg = "";
        ProductDAL _productRepo = ProductDAL.GetInstance();

        [Route("GetAllProducts")]
        public IHttpActionResult GetAllProducts()
        {
            var lstProduct = _productRepo.GetModelList(p => p.Title); //_productRepo.GetProductList(0, 10);
            return Ok(lstProduct);
        }

        [HttpGet]
        [Route("SearchProducts/{keyword}")]
        public IHttpActionResult SearchProducts(string keyword)
        {
            var lstProduct = _productRepo.SearchProductList(keyword);
            return Ok(lstProduct);
        }

        [Route("GetProduct/{id}")]
        public IHttpActionResult GetProduct(int id)
        {
            var product = _productRepo.GetSingleModel(p => p.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [Route("GetProductByCode/{code}")]
        public IHttpActionResult GetProductByCode(string code)
        {
            var product = _productRepo.GetSingleModel(p => p.Code == code);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("CreateProduct")]
        public IHttpActionResult CreateProduct([FromBody]CRM_Product product)
        {
            if (product == null)
            {
                return NotFound();
            }
            var result = _productRepo.CreateModel(product, out errorMsg);
            if (result!=null)
            {
                return Ok();
            }
            else
            {
                return GetErrorResult(errorMsg);
            }

        }

        [AllowAnonymous]
        [HttpPost]
        [Route("CreateOrEditProduct")]
        public IHttpActionResult CreateOrEditProduct([FromBody]CRM_Product product)
        {
            if (product == null)
            {
                return NotFound();
            }
            var result = _productRepo.CreateOrEditModel(product, out errorMsg);
            if (result!=null)
            {
                return Ok();
            }
            else
            {
                return GetErrorResult(errorMsg);
            }

        }
        
    }    
}

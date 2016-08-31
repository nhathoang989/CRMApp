using System.Web.Http;
using HCRM.Data;
using HCRM.DAL.CRM;

namespace HCMS.API.Controllers
{
    [RoutePrefix("api/ReceiptDelivery")]    
    public class ReceiptDeliveryController : BaseApiController
    {
        string errorMsg = "";
        [Route("GetAllReceipts/{pageIndex:int?}/{pageSize:int?}")]
        public IHttpActionResult GetAllReceipts(int? pageIndex = null, int? pageSize = null)
        {
            var lstReceipt = ReceiptDeliveryDAL.Instance.GetModelList(r => r.CreatedDate, "desc", pageIndex, pageSize);
            return Ok(lstReceipt);
        }

        [HttpGet]
        [Route("SearchReceipts/{keyword}")]
        public IHttpActionResult SearchReceipts(string keyword)
        {
            var lstReceipt = ReceiptDeliveryDAL.Instance.SearchReceiptList(keyword);
            return Ok(lstReceipt);
        }

        [Route("GetReceipt/{id}")]
        public IHttpActionResult GetReceipt(int id)
        {
            var Receipt = ReceiptDeliveryDAL.Instance.GetSingleModel(r => r.ReceiptID == id);
            if (Receipt == null)
            {
                return NotFound();
            }
            return Ok(Receipt);
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("CreateReceipt")]
        public IHttpActionResult CreateReceipt([FromBody]CRM_Receipt_Delivery Receipt)
        {          
            if (Receipt == null)
            {
                return NotFound();
            }
            var result = ReceiptDeliveryDAL.Instance.CreateModel(Receipt, out errorMsg);
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
        [Route("CreateOrEditReceipt")]
        public IHttpActionResult CreateOrEditReceipt([FromBody]CRM_Receipt_Delivery Receipt)
        {
            if (Receipt == null)
            {
                return NotFound();
            }
            var result = ReceiptDeliveryDAL.Instance.SaveModel(Receipt, out errorMsg);
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

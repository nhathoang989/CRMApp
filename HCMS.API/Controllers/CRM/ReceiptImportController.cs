using System.Web.Http;
using HCRM.Data;
using HCRM.DAL.CRM;

namespace HCMS.API.Controllers.CRM
{
    [RoutePrefix("api/ReceiptImport")]
    public class ReceiptImportController : BaseCRMController<CRM_Receipt_Import>
    {
        [HttpGet]
        [Route("SearchModelList/{keyword}")]
        public IHttpActionResult SearchReceipts(string keyword)
        {
            var lstReceipt = ReceiptImportDAL.Instance.SearchReceiptList(keyword);
            return Ok(lstReceipt);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("GetModelList/{pageIndex:int?}/{pageSize:int?}")]
        public IHttpActionResult GetReceiptList(int? pageIndex = null, int? pageSize = null)
        {
            string direction = "desc";
            var lstReceipt = ReceiptImportDAL.Instance.GetModelList(e => e.CreatedDate, direction, pageIndex, pageSize);
            foreach (var receipt in lstReceipt)
            {
                receipt.CRM_Receipt_Details =  ReceiptDetailsDAL.Instance.GetModelListBy(d => d.ReceiptImportID == receipt.ReceiptID, d => d.ReceiptDetailsID, "desc", null, null);
                foreach (var details in receipt.CRM_Receipt_Details)
                {
                    details.CRM_Product = ProductDAL.Instance.GetSingleModel(p => p.ProductID == details.ProductID);
                }
                receipt.CRM_Employee = EmployeeDAL.Instance.GetSingleModel(e => e.EmployeeID == receipt.EmployeeID);
                receipt.CRM_Provider = ProviderDAL.Instance.GetSingleModel(e => e.ProviderID == receipt.ProviderID);
            }
            return Ok(lstReceipt);

        }

        [AllowAnonymous]
        [HttpPost]
        [Route("RemoveModel")]
        public IHttpActionResult RemoveReceipt([FromBody]CRM_Receipt_Import model)
        {
            return RemoveModel(model);

        }
        [Route("GetSingleModel/{id}")]
        public IHttpActionResult GetReceipt(int id)
        {
            var Receipt = ReceiptImportDAL.Instance.GetSingleModel(e => e.ReceiptID == id);           
            return NotFound();

        }

        [AllowAnonymous]
        [HttpPost]
        [Route("SaveModel")]
        public IHttpActionResult SaveReceipt([FromBody]CRM_Receipt_Import model)
        {
            string error = "";
            var e = ReceiptImportDAL.Instance.SaveReceipt(model, out error);
            if (string.IsNullOrEmpty(error))
            {
                return Ok(e);
            }
            return BadRequest();
        }
    }
}
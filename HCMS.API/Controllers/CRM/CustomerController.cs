using System.Web.Http;
using HCRM.Data;
using HCRM.DAL.CRM;

namespace HCMS.API.Controllers.CRM
{
    [RoutePrefix("api/Customer")]
    public class CustomerController : BaseApiController
    {
        string errorMsg = "";
        CustomerDAL _CustomerRepo = CustomerDAL.GetInstance();

        [Route("GetCustomerList/{pageIndex:int?}/{pageSize:int?}")]
        public IHttpActionResult GetCustomerList(int? pageIndex = null, int? pageSize = null)
        {
            var lstCustomer = _CustomerRepo.GetCustomerList(pageIndex, pageSize);
            return Ok(lstCustomer);
        }

        [HttpGet]
        [Route("SearchCustomers/{keyword}")]
        public IHttpActionResult SearchCustomers(string keyword)
        {
            var lstCustomer = _CustomerRepo.SearchCustomerList(keyword);
            return Ok(lstCustomer);
        }

        [Route("GetCustomer/{id}")]
        public IHttpActionResult GetCustomer(int id)
        {
            var Customer = _CustomerRepo.GetSingleModel(e => e.CustomerID == id);
            if (Customer == null)
            {
                return NotFound();
            }
            return Ok(Customer);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("CreateCustomer")]
        public IHttpActionResult CreateCustomer([FromBody]CRM_Customer Customer)
        {
            if (Customer == null)
            {
                return NotFound();
            }
            var result = _CustomerRepo.CreateModel(Customer, out errorMsg);
            if (result != null)
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
        [Route("CreateOrEditCustomer")]
        public IHttpActionResult CreateOrEditCustomer([FromBody]CRM_Customer Customer)
        {
            CRM_Customer result = null;
            if (Customer == null)
            {
                return NotFound();
            }

            result = _CustomerRepo.CreateOrUpdateCustomer(Customer, out errorMsg);

            if (result != null)
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
using System.Web.Http;
using HCRM.Data;
using HCRM.DAL.CRM;
using HCRM.DAL;

namespace HCMS.API.Controllers.CRM
{
    [RoutePrefix("api/Customer")]
    public class CustomerController : BaseCRMController<CRM_Customer>
    {

        [HttpGet]
        [Route("SearchModelList/{keyword}")]
        public IHttpActionResult SearchCustomers(string keyword)
        {
            var lstCustomer = CustomerDAL.Instance.SearchCustomerList(keyword);
            return Ok(lstCustomer);
        }




        [AllowAnonymous]
        [HttpGet]
        [Route("GetModelList/{pageIndex:int?}/{pageSize:int?}")]
        public IHttpActionResult GetCustomerList(int? pageIndex = null, int? pageSize = null)
        {
            string direction = "asc";
            var lstCustomer = CustomerDAL.Instance.GetModelList(e => e.Name, direction, pageIndex, pageSize);
            foreach (var cus in lstCustomer)
            {
                cus.CRM_Address = AddressDAL.Instance.GetModelListBy(a => a.CustomerID == cus.CustomerID, a => a.Street, direction, null, null);
            }
            return Ok(lstCustomer);

        }

        [AllowAnonymous]
        [HttpPost]
        [Route("RemoveModel")]
        public IHttpActionResult RemoveCustomer([FromBody]CRM_Customer model)
        {
            return RemoveModel(model);

        }
        [Route("GetSingleModel/{id}")]
        public IHttpActionResult GetCustomer(int id)
        {
            var Customer = CustomerDAL.Instance.GetSingleModel(e => e.CustomerID == id);
            if (Customer != null)
            {
                return Ok(Customer);
            }
            return NotFound();

        }

        [AllowAnonymous]
        [HttpPost]
        [Route("SaveModel")]
        public IHttpActionResult SaveCustomer([FromBody]CRM_Customer model)
        {
            return SaveModel(model);
        }

    }
}
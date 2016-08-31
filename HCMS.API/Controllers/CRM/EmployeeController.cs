using System.Web.Http;
using HCRM.Data;
using HCRM.DAL.CRM;
using HCRM.DAL;

namespace HCMS.API.Controllers.CRM
{
    [RoutePrefix("api/Employee")]
    public class EmployeeController : BaseCRMController<CRM_Employee>
    {
        
        [HttpGet]
        [Route("SearchModelList/{keyword}")]
        public IHttpActionResult SearchEmployees(string keyword)
        {
            var lstEmployee = EmployeeDAL.Instance.SearchEmployeeList(keyword);
            return Ok(lstEmployee);
        }

       


        [AllowAnonymous]
        [HttpGet]
        [Route("GetModelList/{pageIndex:int?}/{pageSize:int?}")]
        public IHttpActionResult GetEmployeeList( int? pageIndex = null, int? pageSize = null)
        {
            string direction = "asc";
            var lstEmployee = EmployeeDAL.Instance.GetModelList(e => e.Name, direction, pageIndex, pageSize);
            foreach (var em in lstEmployee)
            {
                em.CRM_Address = AddressDAL.Instance.GetModelListBy(a => a.EmployeeID == em.EmployeeID, a => a.Street, direction, null, null);
            }
            return Ok(lstEmployee);

        }

        [AllowAnonymous]
        [HttpPost]
        [Route("RemoveModel")]
        public IHttpActionResult RemoveEmployee([FromBody]CRM_Employee model)
        {
            return RemoveModel(model);

        }
        [Route("GetSingleModel/{id}")]
        public IHttpActionResult GetEmployee(int id)
        {
            var Employee = EmployeeDAL.Instance.GetSingleModel(e => e.EmployeeID == id);
            if (Employee != null)
            {
                Employee.CRM_Address = AddressDAL.Instance.GetModelListBy(a => a.EmployeeID == Employee.EmployeeID, a => a.Street, "asc", null, null);
                return Ok(Employee);
            }
            return NotFound();
            
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("SaveModel")]
        public IHttpActionResult SaveEmployee([FromBody]CRM_Employee model)
        {
            string error = "";
            var e = EmployeeDAL.Instance.SaveEmployee(model, out error);
            if (string.IsNullOrEmpty(error))
            {
                return Ok(e);
            }
            return BadRequest();
        }

    }
}
using System.Web.Http;
using HCRM.Data;
using HCRM.DAL.CRM;
using HCRM.DAL;

namespace HCMS.API.Controllers.CRM
{
    [RoutePrefix("api/Address")]
    public class AddressController : BaseCRMController<CRM_Address>
    {
        
        [HttpGet]
        [Route("SearchModelList/{keyword}")]
        public IHttpActionResult SearchAddresss(string keyword)
        {
            var lstAddress = AddressDAL.Instance.SearchAddressList(keyword);
            return Ok(lstAddress);
        }

       


        [AllowAnonymous]
        [HttpGet]
        [Route("GetModelList/{pageIndex:int?}/{pageSize:int?}")]
        public IHttpActionResult GetAddressList( int? pageIndex = null, int? pageSize = null)
        {
            string direction = "asc";
            var lstAddress = AddressDAL.Instance.GetModelList(e => e.Street, direction, pageIndex, pageSize);           
            return Ok(lstAddress);

        }

        [AllowAnonymous]
        [HttpPost]
        [Route("RemoveModel")]
        public IHttpActionResult RemoveAddress([FromBody]CRM_Address model)
        {
            return RemoveModel(model);

        }
        [Route("GetSingleModel/{id}")]
        public IHttpActionResult GetAddress(int id)
        {
            var Address = AddressDAL.Instance.GetSingleModel(e => e.AddressID == id);
            if (Address != null)
            {
                return Ok(Address);
            }
            return NotFound();
            
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("SaveModel")]
        public IHttpActionResult SaveAddress([FromBody]CRM_Address model)
        {
            return SaveModel(model);
        }

    }
}
using System.Web.Http;
using HCRM.Data;
using HCRM.DAL.CRM;
using HCRM.DAL;

namespace HCMS.API.Controllers.CRM
{
    [RoutePrefix("api/Provider")]
    public class ProviderController : BaseCRMController<CRM_Provider>
    {

        [HttpGet]
        [Route("SearchModelList/{keyword}")]
        public IHttpActionResult SearchProviders(string keyword)
        {
            var lstProvider = ProviderDAL.Instance.SearchProviderList(keyword);
            return Ok(lstProvider);
        }




        [AllowAnonymous]
        [HttpGet]
        [Route("GetModelList/{pageIndex:int?}/{pageSize:int?}")]
        public IHttpActionResult GetProviderList(int? pageIndex = null, int? pageSize = null)
        {
            string direction = "asc";
            var lstProvider = ProviderDAL.Instance.GetModelList(e => e.Name, direction, pageIndex, pageSize);
            foreach (var pr in lstProvider)
            {
                pr.CRM_Address = AddressDAL.Instance.GetModelListBy(a => a.ProviderID == pr.ProviderID, a => a.Street, direction, null, null);
            }
            return Ok(lstProvider);

        }

        [AllowAnonymous]
        [HttpPost]
        [Route("RemoveModel")]
        public IHttpActionResult RemoveProvider([FromBody]CRM_Provider model)
        {
            return RemoveModel(model);

        }
        [Route("GetSingleModel/{id}")]
        public IHttpActionResult GetProvider(int id)
        {
            var Provider = ProviderDAL.Instance.GetSingleModel(e => e.ProviderID == id);
            if (Provider != null)
            {
                return Ok(Provider);
            }
            return NotFound();

        }

        [AllowAnonymous]
        [HttpPost]
        [Route("SaveModel")]
        public IHttpActionResult SaveProvider([FromBody]CRM_Provider model)
        {
            return SaveModel(model);
        }

    }
}
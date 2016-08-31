using HCRM.DAL.CRM;
using System.Web.Http;

namespace HCMS.API.Controllers
{
    [RoutePrefix("api/Menu")]
    public class MenuController : ApiController
    {
        [Route("GetMenuList/{role}/{level}/{parentID:int?}")]
        public IHttpActionResult GetAllProducts(string role, int level, int? parentID = null)
        {
            return Ok(MenuDAL.GetListMenu(role, parentID, level));
            
        }       
    }
}
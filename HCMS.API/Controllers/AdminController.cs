using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HCMS.API.Controllers
{
    [RoutePrefix("api/Admin")]
    public class AdminController : ApiController
    {
        [Authorize]
        [Route("Home")]
        public IHttpActionResult Get()
        {
            return Ok(Order.CreateOrders());
        }
    }
}

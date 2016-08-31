using HCRM.DAL;
using System;
using System.Linq.Expressions;
using System.Web.Http;

namespace HCMS.API.Controllers.CRM
{
    public class BaseCRMController<T> : ApiController where T : class
    {        

        static BaseDAL<T> _baseDAL = new BaseDAL<T>();
        string errorMsg = "";


        public IHttpActionResult GetSingleModel(Expression<Func<T, bool>> condition)
        {
            var model = _baseDAL.GetSingleModel(condition);
            if (model!=null)
            {
                return Ok(model);
            }
            return NotFound();
        }

        public IHttpActionResult GetModelList(Expression<Func<T, object>> orderBy, string direction="asc", int? pageIndex = null, int? pageSize = null)
        {
            var lstModel = _baseDAL.GetModelList(orderBy, direction, pageIndex, pageSize);
            return Ok(lstModel);
        }

        public IHttpActionResult GetModelListBy(Expression<Func<T, bool>> predicate, Expression<Func<T, int>> orderBy, string direction = "asc", int? pageIndex = null, int? pageSize = null)
        {
            var lstModel = _baseDAL.FindBy(predicate, orderBy, "asc", pageIndex, pageSize);
            return Ok(lstModel);
        }

        public IHttpActionResult SaveModel([FromBody]T model)
        {
            if (model == null)
            {
                return NotFound();
            }

            T result = _baseDAL.SaveModel(model, out errorMsg);

            if (result != null)
            {
                return Ok();
            }
            else
            {
                return GetErrorResult(errorMsg);
            }

        }

        public IHttpActionResult RemoveModel([FromBody]T model)
        {
            if (model == null)
            {
                return NotFound();
            }
            
            var dal = new BaseDAL<T>();
            var result = dal.RemoveModel(model, out errorMsg);
            if (result)
            {
                return Ok();
            }
            else
            {
                return GetErrorResult(errorMsg);
            }

        }
        
        protected IHttpActionResult GetErrorResult(string errorMsg)
        {

            return BadRequest(errorMsg);

        }
    }
}
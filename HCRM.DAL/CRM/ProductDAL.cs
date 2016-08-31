using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using HCRM.Data;

namespace HCRM.DAL.CRM
{
    public class ProductDAL : BaseDAL<CRM_Product>
    {
        private static ProductDAL _productDAL;

        public static ProductDAL Instance
        {
            get
            {
                if (_productDAL == null)
                {
                    _productDAL = new ProductDAL();

                }
                return _productDAL;
            }
        }

        public List<CRM_Product> SearchProductList(string keyword, int? pageIndex=0, int? pageSize = 100)
        {
            using (HCRMEntities context = new HCRMEntities())
            {
                var lstResult = (from m in context.CRM_Product
                                where (m.Title.Contains(keyword)  || m.Source.Contains(keyword) || m.Code.Contains(keyword))
                                select m).ToList();
                lstResult.ForEach(p => context.Entry(p).State = EntityState.Detached);
                return lstResult;
            }
        }     
    }
}

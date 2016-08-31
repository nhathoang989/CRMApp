using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using HCRM.Data;

namespace HCRM.DAL.CRM
{
    public class AddressDAL : BaseDAL<CRM_Address>
    {
        private static AddressDAL _AddressDAL;

        public static AddressDAL Instance
        {
            get
            {
                if (_AddressDAL == null)
                {
                    _AddressDAL = new AddressDAL();

                }
                return _AddressDAL;
            }
        }

        public List<CRM_Address> SearchAddressList(string keyword, int? pageIndex = 0, int? pageSize = 100)
        {
            using (HCRMEntities context = new HCRMEntities())
            {
                var lstResult = (from m in context.CRM_Address
                                 where (m.Street.Contains(keyword) || m.City.Contains(keyword))
                                 select m).ToList();
                lstResult.ForEach(p => context.Entry(p).State = EntityState.Detached);               
                return lstResult;
            }
        }
    }
}

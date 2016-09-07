using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using HCRM.Data;

namespace HCRM.DAL.CRM
{
    public class ProviderDAL : BaseDAL<CRM_Provider>
    {
        private static ProviderDAL _ProviderDAL;

        public static ProviderDAL Instance
        {
            get
            {
                if (_ProviderDAL == null)
                {
                    _ProviderDAL = new ProviderDAL();

                }
                return _ProviderDAL;
            }
        }
        public CRM_Provider SaveProvider(CRM_Provider provider, out string errorMsg)
        {
            errorMsg = "";
            var e = SaveModel(provider, out errorMsg);
            foreach (var address in provider.CRM_Address)
            {
                address.ProviderID = e.ProviderID;
                AddressDAL.Instance.SaveModel(address, out errorMsg);
            }
            return e;
        }
        public List<CRM_Provider> SearchProviderList(string keyword, int? pageIndex = 0, int? pageSize = 100)
        {
            using (HCRMEntities context = new HCRMEntities())
            {
                var lstResult = (from m in context.CRM_Provider
                                 where (m.Name.Contains(keyword) || m.Email.Contains(keyword) || m.PhoneNumber.Contains(keyword))
                                 select m).ToList();
                lstResult.ForEach(p => context.Entry(p).State = EntityState.Detached);
                foreach (var item in lstResult)
                {
                    item.CRM_Address = AddressDAL.Instance.FindBy(a => a.ProviderID == item.ProviderID, c => c.AddressID, "asc", pageIndex, pageSize);
                }
                return lstResult;
            }
        }

        public List<CRM_Provider> GetProviderList(int? pageIndex = 0, int? pageSize = 100)
        {
            using (HCRMEntities context = new HCRMEntities())
            {
                var lstResult = context.CRM_Provider.OrderBy(e => e.Name).Include(e => e.CRM_Address);
                if (pageSize.HasValue)
                {
                    lstResult = lstResult.Skip(pageIndex.Value * pageSize.Value).Take(pageSize.Value);
                }
                return lstResult.ToList();
            }
        }

    }
}

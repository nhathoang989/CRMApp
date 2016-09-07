using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using HCRM.Data;

namespace HCRM.DAL.CRM
{
    public class CustomerDAL : BaseDAL<CRM_Customer>
    {
        private static CustomerDAL _CustomerDAL;

        public static CustomerDAL Instance
        {
            get
            {
                if (_CustomerDAL == null)
                {
                    _CustomerDAL = new CustomerDAL();

                }
                return _CustomerDAL;
            }
        }
        public CRM_Customer SaveCustomer(CRM_Customer customer, out string errorMsg)
        {
            errorMsg = "";
            var e = SaveModel(customer, out errorMsg);
            foreach (var address in customer.CRM_Address)
            {
                address.CustomerID = e.CustomerID;
                AddressDAL.Instance.SaveModel(address, out errorMsg);
            }
            return e;
        }
        public List<CRM_Customer> SearchCustomerList(string keyword, int? pageIndex = 0, int? pageSize = 100)
        {
            using (HCRMEntities context = new HCRMEntities())
            {
                var lstResult = (from m in context.CRM_Customer
                                 where (m.Name.Contains(keyword) || m.Email.Contains(keyword) || m.PhoneNumber.Contains(keyword))
                                 select m).ToList();
                lstResult.ForEach(p => context.Entry(p).State = EntityState.Detached);
                foreach (var item in lstResult)
                {
                    item.CRM_Address = AddressDAL.Instance.FindBy(a => a.CustomerID == item.CustomerID, c => c.AddressID, "asc", pageIndex, pageSize);
                }
                return lstResult;
            }
        }

        public List<CRM_Customer> GetCustomerList(int? pageIndex = 0, int? pageSize = 100)
        {
            using (HCRMEntities context = new HCRMEntities())
            {
                var lstResult = context.CRM_Customer.OrderBy(e => e.Name).Include(e => e.CRM_Address);
                if (pageSize.HasValue)
                {
                    lstResult = lstResult.Skip(pageIndex.Value * pageSize.Value).Take(pageSize.Value);
                }
                return lstResult.ToList();
            }
        }

    }
}

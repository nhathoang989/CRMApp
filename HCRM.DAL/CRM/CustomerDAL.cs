using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using HCRM.Data;

namespace HCRM.DAL.CRM
{
    public class CustomerDAL : BaseDAL<CRM_Customer>
    {
        private static CustomerDAL _CustomerDAL;

        public static CustomerDAL GetInstance()
        {
            if (_CustomerDAL == null)
            {
                _CustomerDAL = new CustomerDAL();

            }
            return _CustomerDAL;
        }
        public CRM_Customer CreateOrUpdateCustomer(CRM_Customer Customer, out string errorMsg)
        {
            using (HCRMEntities context = new HCRMEntities())
            {
                errorMsg = "";
                context.Entry(Customer).State = Exists(Customer) ? EntityState.Modified : EntityState.Added;


                foreach (var address in Customer.CRM_Address)
                {
                    context.Entry(address).State = AddressDAL.Instance.Exists(address) ? EntityState.Modified : EntityState.Added;
                }
                context.SaveChanges();
                return Customer;
            }
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
                var lstResult = GetModelList(c => c.Name, "asc", pageIndex, pageSize);
                foreach (var item in lstResult)
                {
                    item.CRM_Address = AddressDAL.Instance.FindBy(a => a.CustomerID == item.CustomerID, c => c.AddressID, "asc", pageIndex, pageSize);
                }
                return lstResult.ToList();
            }
        }

    }
}

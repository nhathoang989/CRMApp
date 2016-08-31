using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using HCRM.Data;

namespace HCRM.DAL.CRM
{
    public class EmployeeDAL: BaseDAL<CRM_Employee>
    {  
        private static EmployeeDAL _EmployeeDAL;

        public static EmployeeDAL Instance
        {
            get
            {
                if (_EmployeeDAL == null)
                {
                    _EmployeeDAL = new EmployeeDAL();

                }
                return _EmployeeDAL;
            }
        }
        public CRM_Employee SaveEmployee(CRM_Employee employee, out string errorMsg)
        {
            errorMsg = "";
            var e = SaveModel(employee, out errorMsg);
            foreach (var address in employee.CRM_Address)
            {
                address.EmployeeID = e.EmployeeID;
                AddressDAL.Instance.SaveModel(address, out errorMsg);
            }
            return e;
        }
        public List<CRM_Employee> SearchEmployeeList(string keyword, int? pageIndex = 0, int? pageSize = 100)
        {
            using (HCRMEntities context = new HCRMEntities())
            {
                var lstResult = (from m in context.CRM_Employee
                                 where (m.Name.Contains(keyword) || m.Email.Contains(keyword) || m.PhoneNumber.Contains(keyword))
                                 select m).ToList();                
                lstResult.ForEach(p => context.Entry(p).State = EntityState.Detached);
                foreach (var item in lstResult)
                {
                    item.CRM_Address = AddressDAL.Instance.FindBy(a => a.EmployeeID == item.EmployeeID, c => c.AddressID, "asc", pageIndex, pageSize);
                }
                return lstResult;
            }
        }

        public List<CRM_Employee> GetEmployeeList(int? pageIndex = 0, int? pageSize = 100)
        {
            using (HCRMEntities context = new HCRMEntities())
            {
                var lstResult = context.CRM_Employee.OrderBy(e => e.Name).Include(e=>e.CRM_Address);
                if (pageSize.HasValue)
                {
                    lstResult = lstResult.Skip(pageIndex.Value * pageSize.Value).Take(pageSize.Value);
                }
                return lstResult.ToList();
            }
        }

    }
}

using HCRM.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using HCRM.WarehouseApp.Ultilities;
using System.IO;
using HCRM.WarehouseApp.ViewModels.ElementViewModels;
using HCRM.WarehouseApp.Helpers;
using RestSharp;

namespace HCRM.WarehouseApp.Repositories
{
    public class EmployeeRepo:BaseRepo<CRM_Employee, EmployeeViewModel>
    {
        private static EmployeeRepo _instance;
        public static EmployeeRepo Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EmployeeRepo();
                }
                return _instance;
            }
        }
        public EmployeeRepo() : base("api/Employee", "Employee")
        {
        }

        
    }
}

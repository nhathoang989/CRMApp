using HCRM.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using HCRM.App.Ultilities;
using System.IO;
using HCRM.App.ViewModels.ElementViewModels;
using HCRM.App.Helpers;
using RestSharp;

namespace HCRM.App.Repositories
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

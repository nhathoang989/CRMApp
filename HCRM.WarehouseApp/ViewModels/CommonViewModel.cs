using HCRM.Data;
using HCRM.WarehouseApp.Helpers;
using System.Collections.Generic;

namespace HCRM.WarehouseApp.ViewModels
{
    public class CommonViewModel
    {
        private static CommonViewModel _commonViewModel { get;  set; }
        private List<CRM_Employee> _lstAllEmployee;
        private List<CRM_Product> _lstAllProduct;
        private List<CRM_Customer> _lstAllCustomer;
        private List<CRM_Provider> _lstAllProvider;

        public List<CRM_Employee> LstAllEmployee
        {
            get
            {
                return _lstAllEmployee;
            }

            set
            {
                _lstAllEmployee = value;
            }
        }

        public List<CRM_Customer> LstAllCustomer
        {
            get
            {
                return _lstAllCustomer;
            }

            set
            {
                _lstAllCustomer = value;
            }
        }

        public List<CRM_Product> LstAllProduct
        {
            get
            {
                return _lstAllProduct;
            }

            set
            {
                _lstAllProduct = value;
            }
        }

        public List<CRM_Provider> LstAllProvider
        {
            get
            {
                return _lstAllProvider;
            }

            set
            {
                _lstAllProvider = value;
            }
        }

        public static CommonViewModel GetInstance() {
            return new CommonViewModel();
        }

        async void LoadModels() {
            LstAllEmployee = await EmployeeHelper.GetEmployeeList();
            LstAllProduct = await ProductHelper.GetProductList();
            //LstAllCustomer = await CustomerHelper.GetCustomerList();
        }
        public CommonViewModel()
        {
            LoadModels();
        }
    }
}

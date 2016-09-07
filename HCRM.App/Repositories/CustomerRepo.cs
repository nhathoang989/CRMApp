using HCRM.App.ViewModels;
using HCRM.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using HCRM.App.Ultilities;
using System.IO;
using HCRM.App.Helpers;
using HCRM.App.ViewModels.ElementViewModels;

namespace HCRM.App.Repositories
{
    public class CustomerRepo: BaseRepo<CRM_Customer, CustomerViewModel>
    {
        private static CustomerRepo _instance;
        public static CustomerRepo Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CustomerRepo();
                }
                return _instance;
            }
        }

        public CustomerRepo() : base("api/Customer", "Customer")
        {
        }

        //    public static async Task<bool> CreateOrEditCustomer(CRM_Customer Customer, FileInfo avatar)
        //    {
        //        if (avatar != null)
        //        {
        //            Customer.Avatar = common.SaveFile("Customer", avatar);
        //        }
        //        var rsp = await ApiHelper.postApi<CRM_Customer>(Customer, "api/Customer/CreateOrEditCustomer");
        //        return rsp.StatusCode == System.Net.HttpStatusCode.OK;
        //    }

        //    public static async Task<CRM_Customer> GetCustomer(long CustomerID)
        //    {
        //        string apiURL = Path.Combine("api/Customer/GetCustomer", CustomerID.ToString());
        //        var rsp = await ApiHelper.getApi<CRM_Customer>(Helpers.Parameters.ApiContentType.XWWWForm, apiURL, new List<Helpers.Parameters.ApiParameter>());
        //        CRM_Customer model = rsp.Data;
        //        return model;
        //    }

        //    public static async Task<CRM_Customer> GetCustomerByCode(string code)
        //    {
        //        string apiURL = Path.Combine("api/Customer/GetCustomerByCode", code);
        //        var rsp = await ApiHelper.getApi<CRM_Customer>(Helpers.Parameters.ApiContentType.XWWWForm, apiURL, new List<Helpers.Parameters.ApiParameter>());
        //        return rsp.Data;
        //    }

        //    public static async Task<List<CRM_Customer>> GetCustomerList(int? pageIndex = null, int? pageSize = null)
        //    {
        //        string apiURL = Path.Combine("api/Customer/GetCustomerList", (pageIndex.HasValue ? pageIndex.Value.ToString() : ""), (pageSize.HasValue ? pageSize.Value.ToString() : ""));
        //        var rsp = await ApiHelper.getApi<List<CRM_Customer>>(Helpers.Parameters.ApiContentType.XWWWForm, apiURL, new List<Helpers.Parameters.ApiParameter>());
        //        return common.ParseObject<List<CRM_Customer>>(rsp.Content);
        //    }

        //    public static async Task<List<CRM_Customer>> SearchCustomers(string keyword)
        //    {
        //        string apiURL = Path.Combine("api/Customer/SearchCustomers", keyword);
        //        var rsp = await ApiHelper.getApi<List<CRM_Customer>>(Helpers.Parameters.ApiContentType.XWWWForm, apiURL, new List<Helpers.Parameters.ApiParameter>());
        //        return common.ParseObject<List<CRM_Customer>>(rsp.Content);
        //    }

    }
}

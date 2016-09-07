using HCRM.Data;
using HCRM.App.ViewModels.ElementViewModels;

namespace HCRM.App.Repositories
{
    public class ReceiptImportRepo : BaseRepo<CRM_Receipt_Import, ReceiptImportViewModel>
    {
        private static ReceiptImportRepo _instance;
        public static ReceiptImportRepo Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ReceiptImportRepo();
                }
                return _instance;
            }
        }
        public ReceiptImportRepo() : base("api/ReceiptImport", "ReceiptImport")
        {
        }


    }
    //public class ReceiptRepo
    //{
    //    static string receiptImportApiURL = "api/ReceiptImport/";

    //    public static async Task<bool> CreateOrEditReceipt(CRM_Receipt_Import receipt)
    //    {
    //        var rsp = await ApiHelper.postApi<CRM_Receipt_Import>(receipt, receiptImportApiURL + "CreateReceipt");
    //        if (rsp.StatusCode == System.Net.HttpStatusCode.OK)
    //        {
    //            return true;
    //        }
    //        else
    //        {
    //            return false;
    //        }

    //    }

    //    public static async Task<bool> CreateReceipt(CRM_Receipt_Import receipt)
    //    {
    //        var rsp = await ApiHelper.postApi<CRM_Receipt_Import>(receipt, receiptImportApiURL + "CreateReceipt");
    //        if (rsp.StatusCode == System.Net.HttpStatusCode.OK)
    //        {
    //            return true;
    //        }
    //        else
    //        {
    //            return false;
    //        }
    //    }
    //}
}

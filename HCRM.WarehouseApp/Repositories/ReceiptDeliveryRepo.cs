using HCRM.Data;
using HCRM.WarehouseApp.ViewModels.ElementViewModels;

namespace HCRM.WarehouseApp.Repositories
{
    public class ReceiptDeliveryRepo : BaseRepo<CRM_Receipt_Delivery, ReceiptDeliveryViewModel>
    {
        private static ReceiptDeliveryRepo _instance;
        public static ReceiptDeliveryRepo Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ReceiptDeliveryRepo();
                }
                return _instance;
            }
        }
        public ReceiptDeliveryRepo() : base("api/ReceiptDelivery", "ReceiptDelivery")
        {
        }


    }
    //public class ReceiptRepo
    //{
    //    static string receiptDeliveryApiURL = "api/ReceiptDelivery/";

    //    public static async Task<bool> CreateOrEditReceipt(CRM_Receipt_Delivery receipt)
    //    {
    //        var rsp = await ApiHelper.postApi<CRM_Receipt_Delivery>(receipt, receiptDeliveryApiURL + "CreateReceipt");
    //        if (rsp.StatusCode == System.Net.HttpStatusCode.OK)
    //        {
    //            return true;
    //        }
    //        else
    //        {
    //            return false;
    //        }

    //    }

    //    public static async Task<bool> CreateReceipt(CRM_Receipt_Delivery receipt)
    //    {
    //        var rsp = await ApiHelper.postApi<CRM_Receipt_Delivery>(receipt, receiptDeliveryApiURL + "CreateReceipt");
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

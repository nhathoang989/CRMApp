using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using HCRM.Data;

namespace HCRM.DAL.CRM
{
    public class ReceiptDeliveryDAL: BaseDAL<CRM_Receipt_Delivery>
    {
        private static ReceiptDeliveryDAL _ReceiptDAL;

        public static ReceiptDeliveryDAL Instance
        {
            get
            {
                if (_ReceiptDAL == null)
                {
                    _ReceiptDAL = new ReceiptDeliveryDAL();

                }
                return _ReceiptDAL;
            }
        }
        public CRM_Receipt_Delivery SaveReceipt(CRM_Receipt_Delivery receipt, out string errorMsg)
        {
            errorMsg = "";
            var model = SaveModel(receipt, out errorMsg);
            foreach (var details in receipt.CRM_Receipt_Details)
            {
                details.ReceiptDeliveryID = model.ReceiptID;
                ReceiptDetailsDAL.Instance.SaveModel(details, out errorMsg);
            }
            return model;
        }

        public List<CRM_Receipt_Delivery> SearchReceiptList(string keyword, int? pageIndex=0, int? pageSize = 100)
        {
            using (HCRMEntities context = new HCRMEntities())
            {
                var lstResult = (from m in context.CRM_Receipt_Delivery
                                where (m.OrderName.Contains(keyword)  || m.OrderAddress.Contains(keyword) || m.OrderPhone.Contains(keyword))
                                select m).ToList();
                lstResult.ForEach(p => context.Entry(p).State = EntityState.Detached);
                return lstResult;
            }
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using HCRM.Data;

namespace HCRM.DAL.CRM
{
    public class ReceiptImportDAL: BaseDAL<CRM_Receipt_Import>
    {
        private static ReceiptImportDAL _ReceiptDAL;

        public static ReceiptImportDAL Instance
        {
            get
            {
                if (_ReceiptDAL == null)
                {
                    _ReceiptDAL = new ReceiptImportDAL();

                }
                return _ReceiptDAL;
            }
        }
        public CRM_Receipt_Import SaveReceipt(CRM_Receipt_Import receipt, out string errorMsg)
        {
            errorMsg = "";
            if (receipt.CRM_Provider!=null)
            {
                CRM_Provider provider = ProviderDAL.Instance.SaveProvider(receipt.CRM_Provider, out errorMsg);
                receipt.ProviderID = provider.ProviderID;
                receipt.CRM_Provider = null;
            }
          
            var lstDetails = receipt.CRM_Receipt_Details.ToList();
            receipt.CRM_Employee = null;
            receipt.CRM_Receipt_Details = null;
            var model = SaveModel(receipt, out errorMsg);

            foreach (var details in lstDetails)
            {
                CRM_Product product = details.CRM_Product;

                details.CRM_Product = null;
                details.ReceiptImportID = model.ReceiptID;
                ReceiptDetailsDAL.Instance.SaveModel(details, out errorMsg);

                
                product.TotalRemain -= details.Quantity;
                product.TotalSaled += details.Quantity;
                ProductDAL.Instance.SaveModel(product,out errorMsg);
            }
            return model;
        }

        public List<CRM_Receipt_Import> SearchReceiptList(string keyword, int? pageIndex=0, int? pageSize = 100)
        {
            using (HCRMEntities context = new HCRMEntities())
            {
                var lstResult = (from m in context.CRM_Receipt_Import
                                //where (m.OrderName.Contains(keyword)  || m.OrderAddress.Contains(keyword) || m.OrderPhone.Contains(keyword))
                                select m).ToList();
                lstResult.ForEach(p => context.Entry(p).State = EntityState.Detached);
                return lstResult;
            }
        }
    }
}

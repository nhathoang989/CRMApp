﻿using System.Collections.Generic;
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
            var lstDetails = receipt.CRM_Receipt_Details.ToList();
            if (receipt.CRM_Customer!=null)
            {
                CRM_Customer cus = CustomerDAL.Instance.SaveCustomer(receipt.CRM_Customer, out errorMsg);
                receipt.CustomerID = cus.CustomerID;
                receipt.CRM_Customer = null;
            }

            receipt.CRM_Employee = null;
            receipt.CRM_Receipt_Details = null;
            var model = SaveModel(receipt, out errorMsg);

            foreach (var details in lstDetails)
            {
                CRM_Product product = details.CRM_Product;

                details.CRM_Product = null;
                details.ReceiptDeliveryID = model.ReceiptID;
                ReceiptDetailsDAL.Instance.SaveModel(details, out errorMsg);
                product.TotalRemain -= details.Quantity;
                product.TotalSaled += details.Quantity;
                ProductDAL.Instance.SaveModel(product,out errorMsg);
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

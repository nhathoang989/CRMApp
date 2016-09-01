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
    public class ReceiptDetailsRepo:BaseRepo<CRM_Receipt_Details, ReceiptDetailsViewModel>
    {
        private static ReceiptDetailsRepo _instance;
        public static ReceiptDetailsRepo Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ReceiptDetailsRepo();
                }
                return _instance;
            }
        }
        public ReceiptDetailsRepo() : base("api/ReceiptDetails", "ReceiptDetails")
        {
        }

        
    }
}

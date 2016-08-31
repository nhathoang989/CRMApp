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

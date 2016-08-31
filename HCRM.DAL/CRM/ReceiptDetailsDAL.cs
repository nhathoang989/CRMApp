using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using HCRM.Data;

namespace HCRM.DAL.CRM
{
    public class ReceiptDetailsDAL : BaseDAL<CRM_Receipt_Details>
    {
        private static ReceiptDetailsDAL _ReceiptDetailsDAL;

        public static ReceiptDetailsDAL Instance
        {
            get
            {
                if (_ReceiptDetailsDAL == null)
                {
                    _ReceiptDetailsDAL = new ReceiptDetailsDAL();

                }
                return _ReceiptDetailsDAL;
            }
        }
    }
}

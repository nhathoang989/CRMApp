using HCRM.WarehouseApp.Framework;
using HCRM.WarehouseApp.ViewInterfaces;
using HCRM.WarehouseApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCRM.WarehouseApp.ViewModels
{
    class HomeViewModel : ObjectBase, IPageViewModel
    {        

        public string PageTitle
        {
            get
            {
                return "Home Page";
            }
        }

        public string Key
        {
            get
            {
                return "Home";
            }
        }

        public int ErrorCount
        {
            get
            {
                return ErrorCount;
            }

            set
            {
                ErrorCount = value;
            }
        }
    }
}

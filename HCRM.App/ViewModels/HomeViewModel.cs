using HCRM.App.Framework;
using HCRM.App.ViewInterfaces;
using HCRM.App.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCRM.App.ViewModels
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

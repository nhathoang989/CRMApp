using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCRM.WarehouseApp.ViewInterfaces
{
    public interface IPageViewModel
    {
        string PageTitle { get; }
        string Key { get; }

    }
}

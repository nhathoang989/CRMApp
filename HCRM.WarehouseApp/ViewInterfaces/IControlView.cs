using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCRM.WarehouseApp.ViewInterfaces
{
    interface IControlView : IView
    {
        string Title { get; }
        string Key { get; }
    }
}

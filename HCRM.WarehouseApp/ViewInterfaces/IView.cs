using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCRM.WarehouseApp.ViewInterfaces
{
    public interface IView
    {
        object DataContext { get; set; }
        void Close();
    }
}

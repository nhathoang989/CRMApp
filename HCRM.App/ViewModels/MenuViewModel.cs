using HCRM.App.ViewInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCRM.App.ViewModels
{
    public class MenuViewModel
    {
        public string Key;
        public IPageViewModel Model;
        public List<IPageViewModel> SubModels;
        public MenuViewModel(string key, IPageViewModel page)
        {
            Key = key;
            Model = page;
        }
        public MenuViewModel(string key, IPageViewModel page, List<IPageViewModel> subPages)
        {
            Key = key;
            Model = page;
            SubModels = subPages;
        }

    }
}

using System.Collections.Generic;
using HCRM.WarehouseApp.ViewModels;
using HCRM.Data;

namespace HCRM.WarehouseApp.Repositories
{
    class MenuRepo
    {
        public static MenuViewModel GetPageView(string menuArg) {
            switch (menuArg.ToLower())
            {
                case "login":
                    return new MenuViewModel("Login", new LoginViewModel());
                default:
                    return new MenuViewModel("Home", new HomeViewModel());
            }
        }

        //public async void LoadMenuByRole(string role, MenuButton roleMenus = null, List<CRM_Menu> lstMenu = null, MenuButton parent = null, int level = 0)
        //{

        //    if (lstMenu == null)
        //    {
        //        string apiURL = string.Format("api/Menu/GetMenuList/{0}/{1}/{2}", role, 0, string.Empty);

        //        var rsp = await ApiHelper.getApi<List<CRM_Menu>>(Helpers.Parameters.ApiContentType.XWWWForm, apiURL, new List<Helpers.Parameters.ApiParameter>());
        //        lstMenu = rsp.Data;
        //        //lstMenu = MenuDAL.GetListMenu(role, null, 0);
        //        roleMenus = new MenuButton();
        //        roleMenus.Text = role;
        //    }

        //    foreach (var item in lstMenu)
        //    {
        //        if (parent == null)
        //        {
        //            parent = new MenuButton();
        //            parent.Text = item.Name;
        //        }

        //        string apiURL = string.Format("api/Product/GetMenuList/{0}/{1}/{2}", role, level + 1, item.ID);
        //        var rsp = await ApiHelper.getApi<List<CRM_Menu>>(Helpers.Parameters.ApiContentType.XWWWForm, apiURL, new List<Helpers.Parameters.ApiParameter>());
        //        var lstSubMenu = rsp.Data; //MenuDAL.GetListMenu(role, item.ID, level + 1);
        //        if (lstSubMenu.Count > 0)
        //        {
        //            foreach (var subItem in lstSubMenu)
        //            {
        //                if (subItem.ParentID == item.ID)
        //                {
        //                    MenuButton sb = new MenuButton();
        //                    sb.Text = subItem.Name;
        //                    parent.Children.Add(sb);
        //                    LoadMenuByRole(role, roleMenus, lstSubMenu, sb, item.Level + 1);
        //                }

        //            }

        //        }
        //        if (item.Level == 0)
        //        {
        //            roleMenus.Children.Add(parent);
        //            parent = null;
        //            if (lstMenu.IndexOf(item) == lstMenu.Count - 1)
        //            {
        //                //ScrollViewer sv = (ScrollViewer)MainMenu.Content;
        //                //StackPanel sp = (StackPanel)sv.Content;
        //                //sp.Children.Add(roleMenus);
        //                //return roleMenus;
        //            }
        //        }
        //    }

        //}
    }
}

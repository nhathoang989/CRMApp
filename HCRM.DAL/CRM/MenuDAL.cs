using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System;
using HCRM.Data;

namespace HCRM.DAL.CRM
{
    public class MenuDAL
    {
        public static List<CRM_Menu> GetListMenu()
        {
            using (HCRMEntities context = new HCRMEntities())
            {
                List<CRM_Menu> listMenu = context.CRM_Menu.ToList();
                return listMenu;
            }
        }

        public static List<CRM_Role_Menu> GetListMenu(string role)
        {
            using (HCRMEntities context = new HCRMEntities())
            {
                var listMenuByRole = context.CRM_Role_Menu.Include(o => o.CRM_Menu).Where(o => o.Role == role).ToList();
                return listMenuByRole;
            }
        }

        public static List<CRM_Menu> GetListMenu(string role, int? parentID, int level)
        {
            using (HCRMEntities context = new HCRMEntities())
            {
                var listMenuByRole = context.CRM_Role_Menu.Include(o => o.CRM_Menu).Where(o => o.Role == role && o.CRM_Menu.Level == level && o.CRM_Menu.ParentID == parentID).Select(o=>o.CRM_Menu).ToList();
                return listMenuByRole;
            }
        }

        public static CRM_Menu GetMenu(int id)
        {
            using (HCRMEntities context = new HCRMEntities())
            {
                return context.CRM_Menu.FirstOrDefault(o => o.ID == id);
            }
        }

        public static CRM_Menu GetMenu(string name)
        {
            using (HCRMEntities context = new HCRMEntities())
            {
                return context.CRM_Menu.FirstOrDefault(o => o.Name == name);
            }
        }

        public static bool AddOrUpdateMenu(CRM_Menu o)
        {
            if (GetMenu(o.Name) != null)
            {
                return UpdateMenu(o);
            }
            else
            {
                return AddMenu(o);
            }
        }
        public static bool AddMenu(CRM_Menu o)
        {
            bool kq = false;
            using (HCRMEntities context = new HCRMEntities())
            {
                try
                {
                    context.CRM_Menu.Add(o);
                    context.SaveChanges();
                    kq = true;

                }
                catch (Exception ex)
                {
                    kq = false;
                }
            }
            return kq;
        }
        public static bool UpdateMenu(CRM_Menu o)
        {
            bool kq = false;
            using (HCRMEntities context = new HCRMEntities())
            {
                var model = context.CRM_Menu.FirstOrDefault(modelr => modelr.Name == o.Name);
                model.Name = o.Name;
                model.Path = o.Path;
                model.Type = o.Type;
                context.SaveChanges();
                kq = true;
            }
            return kq;
        }
        public static bool DeleteMenu(int id)
        {
            bool kq = false;

            using (HCRMEntities context = new HCRMEntities())
            {
                var p = context.CRM_Menu.Where(t => t.ID == id).First();
                context.SaveChanges();
                kq = true;
            }
            //TechStore.ProvMenuIders.GlobalProvMenuIder.listmodelram = TechStore.DAL.MenuDAL.GetListMenu();
            return kq;
        }
    }
}

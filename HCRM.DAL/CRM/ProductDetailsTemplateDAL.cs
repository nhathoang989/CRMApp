using HCRM.Data;
using System;
using System.Collections.Generic;
using System.Linq;


namespace HCRM.DAL.CRM
{
    public class ProductDetailsTemplateDAL
    {
        public static List<CRM_Product_Details_Template> GetListTemplate()
        {
            using (HCRMEntities context = new HCRMEntities())
            {
                List<CRM_Product_Details_Template> listTemplate = context.CRM_Product_Details_Template.ToList();
                return listTemplate;
            }
        }

        public static CRM_Product_Details_Template GetTemplate(int id)
        {
            using (HCRMEntities context = new HCRMEntities())
            {
                return context.CRM_Product_Details_Template.FirstOrDefault(p => p.ID == id);
            }
        }

        public static CRM_Product_Details_Template GetTemplate(string name)
        {
            using (HCRMEntities context = new HCRMEntities())
            {
                return context.CRM_Product_Details_Template.FirstOrDefault(p => p.Name == name);
            }
        }

        public static bool AddOrUpdateTemplate(CRM_Product_Details_Template p)
        {
            if (GetTemplate(p.Name) != null)
            {
                return UpdateTemplate(p);
            }
            else
            {
                return AddTemplate(p);
            }
        }
        public static bool AddTemplate(CRM_Product_Details_Template p)
        {
            bool kq = false;
            using (HCRMEntities context = new HCRMEntities())
            {
                try
                {
                    context.CRM_Product_Details_Template.Add(p);
                    context.SaveChanges();
                    kq = true;

                }
                catch (Exception)
                {
                    kq = false;
                }
            }
            return kq;
        }
        public static bool UpdateTemplate(CRM_Product_Details_Template p)
        {
            bool kq = false;
            using (HCRMEntities context = new HCRMEntities())
            {
                var pa = context.CRM_Product_Details_Template.FirstOrDefault(par => par.Name == p.Name);
                pa.Name = p.Name;
                pa.Template = p.Template;
                pa.CateID = p.CateID;
                context.SaveChanges();
                kq = true;
            }
            return kq;
        }
        public static bool DeleteTemplate(int id)
        {
            bool kq = false;

            using (HCRMEntities context = new HCRMEntities())
            {
                var p = context.CRM_Product_Details_Template.Where(t => t.ID == id).First();
                context.SaveChanges();
                kq = true;
            }
            //TechStore.ProvTemplateIders.GlobalProvTemplateIder.listparam = TechStore.DAL.TemplateDAL.GetListTemplate();
            return kq;
        }
    }



}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using HCRM.Data;

namespace HCRM.DAL.CRM
{
    public class ProviderDAL
    {

        public static bool CreateProvider(CRM_Provider model, out string errorMsg)
        {
            try
            {
                errorMsg = "";
                using (HCRMEntities context = new HCRMEntities())
                {
                    context.CRM_Provider.Add(model);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                return false;
            }
        }

        public static bool EditProvider(CRM_Provider model, out string errorMsg)
        {
            errorMsg = "";
            bool result = false;
            try
            {
                using (HCRMEntities context = new HCRMEntities())
                {
                    var Provider = GetProvider(model.ProviderID);
                    if (Provider != null)
                    {
                        Provider = model;
                        context.SaveChanges();
                        result = true; ;
                    }
                    else
                    {
                        errorMsg = "NotFound";
                    }
                }
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;

            }
            return result;
        }

        public static bool RemoveProvider(CRM_Provider model, out string errorMsg)
        {
            errorMsg = "";
            bool result = false;
            try
            {
                using (HCRMEntities context = new HCRMEntities())
                {
                    var Provider = GetProvider(model.ProviderID);
                    if (Provider != null)
                    {
                        Provider = model;
                        context.CRM_Provider.Remove(Provider);
                        context.SaveChanges();
                        result = true; ;
                    }
                    else
                    {
                        errorMsg = "NotFound";
                    }
                }
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;

            }
            return result;
        }

        public static CRM_Provider GetProvider(long ProviderId)
        {
            try
            {
                CRM_Provider result = null;
                using (HCRMEntities context = new HCRMEntities())
                {
                    result = context.CRM_Provider.First(model => model.ProviderID == ProviderId);
                }
                return result;
            }
            catch
            {
                return null;
            }
        }

        public static List<CRM_Provider> GetProviderList(int pageIndex, int pageSize)
        {
            using (HCRMEntities context = new HCRMEntities())
            {
                var g = (from model in context.CRM_Provider                                                  
                         select model).Skip(pageIndex * pageSize).Take(pageSize);
                return g.ToList();
            }
        }
    }
}

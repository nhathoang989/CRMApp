using HCRM.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;

namespace HCRM.DAL
{
    public class BaseDAL<T> : IDAL<T> where T : class
    {   
        public Boolean Exists(T entity)
        {
            using (HCRMEntities context = new HCRMEntities())
            {
                var objContext = ((IObjectContextAdapter)context).ObjectContext;
                var objSet = objContext.CreateObjectSet<T>();
                var entityKey = objContext.CreateEntityKey(objSet.EntitySet.Name, entity);

                Object foundEntity;
                var exists = objContext.TryGetObjectByKey(entityKey, out foundEntity);
               
                return (exists);
            }
        }
        public T CreateModel(T model, out string errorMsg)
        {
            T result = null;
            try
            {
                errorMsg = "";
                using (HCRMEntities context = new HCRMEntities())
                {
                    context.Entry(model).State = System.Data.Entity.EntityState.Added;
                    context.SaveChanges();
                    result = model;
                }
            }
            catch (DbEntityValidationException ex)
            {
                var error = ex.EntityValidationErrors.First().ValidationErrors.First();
                errorMsg = error.ErrorMessage;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    errorMsg = ex.InnerException.Message;
                }
                else
                {
                    errorMsg = ex.Message;
                }

            }
            return result;
        }
        public T SaveModel(T model, out string errorMsg)
        {
            errorMsg = "";
            using (HCRMEntities context = new HCRMEntities())
            {
                return !Exists(model) ? CreateModel(model, out errorMsg) : EditModel(model, out errorMsg);
            }
        }

        public T EditModel(T model, out string errorMsg)
        {
            T result = null;
            try
            {
                errorMsg = "";
                using (HCRMEntities context = new HCRMEntities())
                {
                    context.Entry(model).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                    result = model;
                }
            }
            catch (DbEntityValidationException ex)
            {
                var error = ex.EntityValidationErrors.First().ValidationErrors.First();
                errorMsg = error.ErrorMessage;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    errorMsg = ex.InnerException.Message;
                }
                else
                {
                    errorMsg = ex.Message;
                }

            }
            return result;
        }

        public T GetSingleModel(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            using (HCRMEntities context = new HCRMEntities())
            {
                T query = context.Set<T>().Where(predicate).FirstOrDefault();
                context.Entry(query).State = System.Data.Entity.EntityState.Detached;
                return query;
            }
        }        

        public bool RemoveModel(T model, out string errorMsg)
        {
            bool result = false;
            try
            {
                errorMsg = "";
                using (HCRMEntities context = new HCRMEntities())
                {
                    context.Entry(model).State = System.Data.Entity.EntityState.Deleted;
                    context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    errorMsg = ex.InnerException.Message;
                }
                else
                {
                    errorMsg = ex.Message;
                }

            }
            return result;
        }

        public List<T> FindBy(Expression<Func<T, bool>> predicate, Expression<Func<T, int>> orderBy, string direction, int? pageIndex, int? pageSize)
        {
            using (HCRMEntities context = new HCRMEntities())
            {
                List<T> lstResult = new List<T>();

                switch (direction)
                {
                    case "desc":
                        if (pageSize.HasValue)
                        {
                            lstResult = context.Set<T>().Where(predicate).OrderByDescending(orderBy).Skip(pageIndex.Value * pageSize.Value).Take(pageSize.Value).ToList();

                        }
                        else
                        {
                            lstResult = context.Set<T>().Where(predicate).OrderByDescending(orderBy).ToList();
                        }
                        break;
                    default:
                        if (pageSize.HasValue)
                        {
                            lstResult = context.Set<T>().Where(predicate).OrderBy(orderBy).Skip(pageIndex.Value * pageSize.Value).Take(pageSize.Value).ToList();

                        }
                        else
                        {
                            lstResult = context.Set<T>().Where(predicate).OrderBy(orderBy).ToList();
                        }
                        break;
                }
                lstResult.ForEach(p => context.Entry(p).State = EntityState.Detached);

                return lstResult;
            }
        }

        public List<T> GetModelList(System.Linq.Expressions.Expression<Func<T, DateTime>> orderBy, string direction, int? pageIndex, int? pageSize)
        {
            using (HCRMEntities context = new HCRMEntities())
            {                
                List<T> lstResult = new List<T>();
                try
                {

                switch (direction)
                {
                    case "desc":
                        if (pageSize.HasValue)
                        {
                            lstResult = context.Set<T>().OrderByDescending(orderBy).Skip(pageIndex.Value * pageSize.Value).Take(pageSize.Value).ToList();

                        }
                        else
                        {
                            lstResult = context.Set<T>().OrderByDescending(orderBy).ToList();
                        }
                        break;
                    default:
                        if (pageSize.HasValue)
                        {
                            lstResult = context.Set<T>().OrderBy(orderBy).Skip(pageIndex.Value * pageSize.Value).Take(pageSize.Value).ToList();

                        }
                        else
                        {
                            lstResult = context.Set<T>().OrderBy(orderBy).ToList();
                        }                        
                        break;
                }
                lstResult.ForEach(p => context.Entry(p).State = EntityState.Detached);

                }
                catch (Exception)
                {



                }
                return lstResult;   
            }
        }

        public List<T> GetModelList(System.Linq.Expressions.Expression<Func<T, object>> orderBy, string direction, int? pageIndex, int? pageSize)
        {
            using (HCRMEntities context = new HCRMEntities())
            {
                List<T> lstResult = new List<T>();
                switch (direction)
                {
                    case "desc":
                        if (pageSize.HasValue)
                        {
                            lstResult = context.Set<T>().OrderByDescending(orderBy).Skip(pageIndex.Value * pageSize.Value).Take(pageSize.Value).ToList();

                        }
                        else
                        {
                            lstResult = context.Set<T>().OrderByDescending(orderBy).ToList();
                        }
                        break;
                    default:
                        if (pageSize.HasValue)
                        {
                            lstResult = context.Set<T>().OrderBy(orderBy).Skip(pageIndex.Value * pageSize.Value).Take(pageSize.Value).ToList();

                        }
                        else
                        {
                            lstResult = context.Set<T>().OrderBy(orderBy).ToList();
                        }
                        break;
                }
                lstResult.ForEach(p => context.Entry(p).State = EntityState.Detached);
                return lstResult;
            }
        }

        public List<T> GetModelListBy(Expression<Func<T, bool>> condition, Expression<Func<T, object>> orderBy, string direction, int? pageIndex, int? pageSize)
        {
            using (HCRMEntities context = new HCRMEntities())
            {
                List<T> lstResult = new List<T>();
                switch (direction)
                {
                    case "desc":
                        if (pageSize.HasValue)
                        {
                            lstResult = context.Set<T>().Where(condition).OrderByDescending(orderBy).Skip(pageIndex.Value * pageSize.Value).Take(pageSize.Value).ToList();

                        }
                        else
                        {
                            lstResult = context.Set<T>().Where(condition).OrderByDescending(orderBy).ToList();
                        }
                        break;
                    default:
                        if (pageSize.HasValue)
                        {
                            lstResult = context.Set<T>().Where(condition).OrderBy(orderBy).Skip(pageIndex.Value * pageSize.Value).Take(pageSize.Value).ToList();

                        }
                        else
                        {
                            lstResult = context.Set<T>().Where(condition).OrderBy(orderBy).ToList();
                        }
                        break;
                }
                lstResult.ForEach(p => context.Entry(p).State = EntityState.Detached);
                return lstResult;
            }
        }

        //public List<T> GetModelList(System.Linq.Expressions.Expression<Func<T, DateTime?>> orderBy, string direction, int? pageIndex = 0, int? pageSize = 100)
        //{
        //    using (HCRMEntities context = new HCRMEntities())
        //    {
        //        switch (direction)
        //        {
        //            case "desc":
        //                var lstResultDesc = context.Set<T>().OrderByDescending(orderBy).Skip(pageIndex.Value * pageSize.Value).Take(pageSize.Value).ToList();
        //                lstResultDesc.ForEach(p => context.Entry(p).State = EntityState.Detached);
        //                return lstResultDesc;
        //            default:
        //                var lstResult = context.Set<T>().OrderBy(orderBy).Skip(pageIndex.Value * pageSize.Value).Take(pageSize.Value).ToList();
        //                lstResult.ForEach(p => context.Entry(p).State = EntityState.Detached);
        //                return lstResult;
        //        }
        //    }
        //}

    }
}
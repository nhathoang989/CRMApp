using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.API.Interfaces
{
    public interface IDAL<T>
    {
        T CreateModel(T model, out string errorMsg);
        T EditModel(T model, out string errorMsg);
        bool RemoveModel(T model, out string errorMsg);
        T GetSingleModel(Expression<Func<T, bool>> predicate);
        List<T> GetModelList(System.Linq.Expressions.Expression<Func<T, object>> orderBy, string direction, int? pageIndex = 0, int? pageSize = 100);

        List<T> FindBy(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> orderBy, string direction, int? pageIndex, int? pageSize);

        T CreateOrEditModel(T model, out string errorMsg);

    }
}

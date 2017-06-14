using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SSKJ.ISSKJCompanyDAL
{
    public interface IBaseOperationDAL<T> : IQuery<T>, IAdd<T>, IRemove<T>, IModified<T> where T : class
    {
        int SaveChange();
    }

    public interface IQuery<T> where T : class
    {
        IEnumerable<T> Find(Expression<Func<T, bool>> whereLambda);
        IEnumerable<T> FindPaging<S>(int pageIndex, int pageSize, Expression<Func<T, bool>> whereLambda, bool isAsc, Expression<Func<T, S>> orderbyLambda, out int total);
    }

    public interface IAdd<T> where T : class
    {
        T Add(T entity);
    }

    public interface IRemove<T> where T : class
    {
        int Remove(T entity);
    }

    public interface IModified<T> where T : class
    {
        int Modified(T entity);
    }

    public interface ISaveList<T> where T : class
    {
        T SaveList(List<T> list, T model);
    }
}

using System;
using System.Linq;
using System.Linq.Expressions;

namespace Business.Common
{
    public interface IRepository<T>
        where T : class
    {
        void Save(T entity);

        T Read(params object[] keyValues);

        void Update(T entity);

        void Delete(T entity);

        void DeleteBy(params object[] keyValues);

        IQueryable<T> List();

        IQueryable<T> Where(Expression<Func<T, bool>> predicate);

        void Detach(T entity);
    }
}

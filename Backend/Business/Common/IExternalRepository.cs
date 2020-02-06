using System.Linq;

namespace Business.Common
{
    public interface IExternalRepository<T>
        where T : class
    {
        IQueryable<T> List();
    }
}

using Rutine.Domain.Entities;
using System.Linq.Expressions;

namespace Rutine.Domain.Interfaces
{
    public interface IRepository<T> where T : Base
    {
        int Create(T entity);
        void Update(T entity);
        void Delete(int id);


        T Get(int id, string navProps = "");
        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, string navProps = "");
        IEnumerable<T> GetAll(string navProps = "");
    }
}

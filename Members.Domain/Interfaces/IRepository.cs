using Members.Domain.Entities;
using System.Linq.Expressions;

namespace Members.Domain.Interfaces
{
    public interface IRepository<T> where T : Base
    {

        void Create(T entity);
        void Update(T entity);
        void Delete(string id);

        T GetById(string id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetByFilter(Expression<Func<T, bool>> filter = null);
    }
}

using Microsoft.EntityFrameworkCore;
using Rutine.Domain.Entities;
using Rutine.Domain.Interfaces;
using System.Linq.Expressions;

namespace Rutine.Infraestructure.Repository
{
    public class Repository<T> : IRepository<T> where T : Base
    {
        protected readonly DataContext.DataContext _context; 

        public Repository(DataContext.DataContext context)
        {
            _context = context;
        }
        #region Persistence Methods

        public int Create(T entity)
        {
            if (entity == null) throw new Exception("The entity has no values");

            _context.Set<T>().Add(entity);

            return entity.Id;
        }

        public void Delete(int id)
        {
            var entityToDelete = _context.Set<T>().FirstOrDefault(e => e.Id == id);

            if (entityToDelete == null) throw new Exception("Entity doesn't exists");

            _context.Set<T>().Remove(entityToDelete);
        }

        public void Update(T entity)
        {
            if (entity == null) throw new Exception("The entity to modify has no values");

            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        #endregion

        #region Get Methods
        public T Get(int id, string navProps = "")
        {
            var query = navProps.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate<string, IQueryable<T>>(_context.Set<T>(), (current, include) => current.Include(include.Trim()));

            var request = query.FirstOrDefault(x => x.Id == id);

            if (request == null)
                throw new Exception("Object not found");

            return request;
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, string navProps = "")
        {
            var query = navProps.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate<string, IQueryable<T>>(_context.Set<T>(), (current, include) => current.Include(include.Trim()));

            if (filter != null) query = query.Where(filter);

            var request = query.ToList();

            if (request == null)
                throw new Exception("List of objects not found");

            return request;
        }

        public IEnumerable<T> GetAll(string navProps = "")
        {
            var query = navProps.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate<string, IQueryable<T>>(_context.Set<T>(), (current, include) => current.Include(include.Trim()));

            var request = query.ToList();

            if (request == null)
                throw new Exception("List of objects not found");

            return request;
        }

        #endregion

    }
}

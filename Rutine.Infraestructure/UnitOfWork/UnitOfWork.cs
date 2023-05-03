using Rutine.Domain.Entities;
using Rutine.Domain.Interfaces;
using Rutine.Infraestructure.Repository;

namespace Rutine.Infraestructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly DataContext.DataContext _context;

        public UnitOfWork(DataContext.DataContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Disposed()
        {
            _context.Dispose();
        }


        // ====================================================================================================================================== //
        public IRepository<Domain.Entities.Rutine> _rutineRepository;

        public IRepository<Domain.Entities.Rutine> RutineRepository => _rutineRepository ?? (_rutineRepository = new Repository<Domain.Entities.Rutine>(_context));

        // ====================================================================================================================================== //
        public IRepository<RutineDetail> _rutineDetailRepository;

        public IRepository<RutineDetail> RutineDetailRepository => _rutineDetailRepository ?? (_rutineDetailRepository = new Repository<RutineDetail>(_context));

        // ====================================================================================================================================== //
        public IRepository<Exercise> _exerciseRepository;

        public IRepository<Exercise> ExerciseRepository => _exerciseRepository ?? (_exerciseRepository = new Repository<Exercise>(_context));

        
    }
}

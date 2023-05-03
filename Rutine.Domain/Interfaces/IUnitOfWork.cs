using Rutine.Domain.Entities;

namespace Rutine.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        void Commit();

        void Disposed();

        IRepository<Entities.Rutine> RutineRepository { get; }
        IRepository<RutineDetail> RutineDetailRepository { get; }
        IRepository<Exercise> ExerciseRepository { get; }
        
    }
}

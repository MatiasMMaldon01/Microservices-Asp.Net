using Payment.Domain.Entities;

namespace Payment.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        void Commit();

        void Disposed();

        IRepository<PriceList> PriceListRepository { get; }
        IRepository<Entities.Payment> PaymentRepository { get; }
    }
}

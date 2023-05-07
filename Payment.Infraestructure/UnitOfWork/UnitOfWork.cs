using Payment.Domain.Entities;
using Payment.Domain.Interfaces;
using Payment.Infraestructure.Data;
using Payment.Infraestructure.Repository;

namespace Payment.Infraestructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Data.DataContext _context;

        public UnitOfWork(DataContext dataContext)
        {
            _context = dataContext;
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
        public IRepository<PriceList> _priceListRepository;

        public IRepository<PriceList> PriceListRepository => _priceListRepository ?? (_priceListRepository = new Repository<PriceList>(_context));

        // ====================================================================================================================================== //

        public IRepository<Domain.Entities.Payment> _paymentRepository;

        public IRepository<Domain.Entities.Payment> PaymentRepository => _paymentRepository ?? (_paymentRepository = new Repository<Domain.Entities.Payment>(_context));

    }
}

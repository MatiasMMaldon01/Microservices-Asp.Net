using Payment.Domain.Interfaces;
using Payment.IService.Base.DTO;
using Payment.IService.Payment;
using Payment.IService.Payment.DTO;
using Payment.IService.PriceList;
using Payment.IService.PriceList.DTO;
using System.Linq.Expressions;

namespace Payment.Service.PaymentService
{
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPriceListService _priceListService;
        public PaymentService(IUnitOfWork unitOfWork, IPriceListService priceListService)
        {
            _unitOfWork = unitOfWork;
            _priceListService = priceListService;
        }

        public int Create(BaseDTO entity)
        {
            var dto = (PaymentDTO)entity;

            var price = (PriceListDTO) _priceListService.GetCurrentPriceList();

            int newPayment = _unitOfWork.PaymentRepository.Create(new Domain.Entities.Payment
            {
                Amount = price.Amount,
                MemberId = dto.MemberId,
                PayDate = DateTime.Now,
                PriceListId = price.Id,
            });

            _unitOfWork.Commit();

            return newPayment;
        }

        public void Update(BaseDTO entity)
        {
            var dto = (PaymentDTO)entity;

            var paymentToUpdate = _unitOfWork.PaymentRepository.Get(dto.Id);

            if (paymentToUpdate == null) throw new Exception("Payment not found");

            paymentToUpdate.MemberId = dto.MemberId;
            paymentToUpdate.PriceListId = dto.PriceListId;
            paymentToUpdate.PayDate = dto.PayDate;

            _unitOfWork.PaymentRepository.Update(paymentToUpdate);
            _unitOfWork.Commit();     
        }

        public void Delete(int id)
        {
            _unitOfWork.PaymentRepository.Delete(id);
            _unitOfWork.Commit();
        }

        public BaseDTO Get(int id)
        {
            var payment = _unitOfWork.PaymentRepository.Get(id);

            if (payment == null) throw new Exception($"Payment with id {id} not found");

            return new PaymentDTO
            {
                Id = payment.Id,
                Amount = payment.Amount,
                PayDate = payment.PayDate,
                MemberId = payment.MemberId,
                PriceListId = payment.PriceListId,
            };
        }

        public IEnumerable<BaseDTO> Get(string filter)
        {
            Expression<Func<Domain.Entities.Payment, bool>> expressionFilter = x => x.MemberId == filter;

            var response = _unitOfWork.PaymentRepository.Get(expressionFilter);

            if (response == null) throw new Exception($"Opss... no values here");

            return response.Select(p => new PaymentDTO
            {
                Id = p.Id,
                Amount = p.Amount,
                MemberId = p.MemberId,
                PayDate = p.PayDate,
                PriceListId = p.PriceListId,
            }).OrderBy(x => x.PayDate)
                .ToList();
        }

        public IEnumerable<BaseDTO> GetAll()
        {
            var response = _unitOfWork.PaymentRepository.GetAll();

            if (response == null) throw new Exception($"Opss... no values here");

            return response.Select(p => new PaymentDTO
            {
                Id = p.Id,
                Amount = p.Amount,
                MemberId = p.MemberId,
                PayDate = p.PayDate,
                PriceListId = p.PriceListId,

            }).OrderBy(x => x.PayDate)
                .ToList();
        }

    }
}

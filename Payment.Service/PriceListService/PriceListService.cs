using Payment.Domain.Entities;
using Payment.Domain.Interfaces;
using Payment.Domain.Metadata;
using Payment.IService.Base.DTO;
using Payment.IService.PriceList;
using Payment.IService.PriceList.DTO;
using System.Linq.Expressions;

namespace Payment.Service.PriceListService
{
    public class PriceListService : IPriceListService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PriceListService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int Create(BaseDTO entity)
        {
            var dto = (PriceListDTO)entity;

            int newPriceLsit = _unitOfWork.PriceListRepository.Create(new PriceList
            {
                Amount = dto.Amount,
                CreatedAt = dto.CreatedAt,
            });

            _unitOfWork.Commit();

            return newPriceLsit;

        }

        public void Update(BaseDTO entity)
        {
            var dto = (PriceListDTO) entity;

            var priceListUpdate = _unitOfWork.PriceListRepository.Get(dto.Id);

            if (priceListUpdate == null) throw new Exception("Exercise not found");

            priceListUpdate.Amount = dto.Amount;
            priceListUpdate.CreatedAt = dto.CreatedAt;

            _unitOfWork.PriceListRepository.Update(priceListUpdate);

            _unitOfWork.Commit();

        }

        public void Delete(int id)
        {
            _unitOfWork.PriceListRepository.Delete(id);
            _unitOfWork.Commit();
        }

        public BaseDTO Get(int id)
        {
            var priceList = _unitOfWork.PriceListRepository.Get(id);
            if (priceList == null) throw new Exception($"Price list with id {id} not found");

            return new PriceListDTO
            {
                Id = priceList.Id,
                Amount = priceList.Amount,
                CreatedAt = DateTime.Now,
            };
        }

        public IEnumerable<BaseDTO> Get(string filter)
        {
            Expression<Func<PriceList, bool>> filterExpression = x => x.CreatedAt > DateTime.Parse(filter);

            var priceList = _unitOfWork.PriceListRepository.Get(filterExpression);

            if (priceList == null) throw new Exception($"Opss... no values here");

            return priceList.Select(e => new PriceListDTO
            {
                Id = e.Id,
                Amount = e.Amount,
                CreatedAt = e.CreatedAt,

            }).OrderBy(e => e.CreatedAt)
                .ToList();
        }

        public IEnumerable<BaseDTO> GetAll()
        {
            var priceList = _unitOfWork.PriceListRepository.GetAll();

            if (priceList == null) throw new Exception($"Opss... no values here");

            return priceList.Select(e => new PriceListDTO
            {
                Id = e.Id,
                Amount = e.Amount,
                CreatedAt = e.CreatedAt

            }).OrderBy(e => e.CreatedAt)
                .ToList();
        }

        public BaseDTO GetCurrentPriceList()
        {
            var priceList = _unitOfWork.PriceListRepository.GetAll().LastOrDefault();

            if (priceList == null) throw new Exception($"Opss... no values here");

            return new PriceListDTO
            {
                Id = priceList.Id,
                Amount = priceList.Amount,
                CreatedAt = priceList.CreatedAt,
            };
        }
    }
}

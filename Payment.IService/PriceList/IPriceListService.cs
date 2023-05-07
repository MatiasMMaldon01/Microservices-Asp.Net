using Payment.IService.Base;
using Payment.IService.Base.DTO;

namespace Payment.IService.PriceList
{
    public interface IPriceListService : IBaseService
    {
        BaseDTO GetCurrentPriceList();
    }
}

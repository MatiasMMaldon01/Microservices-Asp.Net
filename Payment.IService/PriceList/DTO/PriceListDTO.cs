using Payment.IService.Base.DTO;

namespace Payment.IService.PriceList.DTO
{
    public class PriceListDTO : BaseDTO
    {
        public decimal Amount { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}

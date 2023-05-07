using Payment.IService.Base.DTO;

namespace Payment.IService.Payment.DTO
{
    public class PaymentDTO : BaseDTO
    {
        public decimal Amount { get; set; }

        public DateTime PayDate { get; set; }

        public string MemberId { get; set; }
        
        public int PriceListId { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace Payment.Domain.Metadata
{
    public interface IPayment
    {
        [Required(ErrorMessage = "Required field")]
        [DataType(DataType.Currency)]
        decimal Amount { get; set; }

        [Required(ErrorMessage = "Required field")]
        [DataType(DataType.DateTime)]
        DateTime PayDate { get; set; }

        [Required(ErrorMessage = "Required field")]
        int PriceListId { get; set; }

        [Required(ErrorMessage = "Required field")]
        [StringLength(250)]
        string MemberId { get; set; }
    }
}

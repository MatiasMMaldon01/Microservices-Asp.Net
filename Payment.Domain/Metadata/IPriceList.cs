using System.ComponentModel.DataAnnotations;

namespace Payment.Domain.Metadata
{
    public interface IPriceList
    {
        [Required(ErrorMessage = "Required field")]
        [DataType(DataType.Currency)]
        decimal Amount { get; set; }

        [Required(ErrorMessage = "Required field")]
        [DataType(DataType.DateTime)]
        DateTime CreatedAt { get; set; }
    }
}

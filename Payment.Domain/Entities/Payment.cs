using Payment.Domain.Metadata;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Payment.Domain.Entities
{
    [Table("Payment")]
    [MetadataType(typeof(IPayment))]

    public class Payment : Base
    {
        public decimal Amount { get; set; }

        public DateTime PayDate { get; set; }

        public int PriceListId { get; set; }

        public string MemberId { get; set; }


        public virtual PriceList PriceList { get; set; }
    }
}

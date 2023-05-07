using Payment.Domain.Metadata;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Payment.Domain.Entities
{
    [Table("PriceList")]
    [MetadataType(typeof(IPriceList))]

    public class PriceList : Base
    {
        public decimal Amount { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}

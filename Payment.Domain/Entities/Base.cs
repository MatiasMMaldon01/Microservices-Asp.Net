using System.ComponentModel.DataAnnotations;

namespace Payment.Domain.Entities
{
    public class Base
    {
        [Key]
        public int Id { get; set; }
    }
}

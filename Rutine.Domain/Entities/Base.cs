using System.ComponentModel.DataAnnotations;

namespace Rutine.Domain.Entities
{
    public class Base
    {
        [Key]
        public int Id { get; set; }
    }
}

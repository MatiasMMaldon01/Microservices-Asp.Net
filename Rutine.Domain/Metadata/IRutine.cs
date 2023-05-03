using System.ComponentModel.DataAnnotations;

namespace Rutine.Domain.Metadata
{
    public interface IRutine
    {
        [Required(ErrorMessage = "Required field")]
        [StringLength(250)]
        string MemberId { get; set; }

        [Required(ErrorMessage = "Required field")]
        [DataType(DataType.DateTime)]
        DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Required field")]
        [DataType(DataType.DateTime)]
        DateTime EndDate { get; set; }
    }
}

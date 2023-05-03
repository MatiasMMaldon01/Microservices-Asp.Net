using System.ComponentModel.DataAnnotations;

namespace Rutine.Domain.Metadata
{
    public interface IExercise
    {
        [Required(ErrorMessage = "Required field")]
        [StringLength(250)]
        string Muscle { get; set; }

        [Required(ErrorMessage = "Required field")]
        [StringLength(250)]
        string Description { get; set; }
    }
}

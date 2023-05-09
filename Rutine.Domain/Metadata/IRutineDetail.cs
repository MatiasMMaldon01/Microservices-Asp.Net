using System.ComponentModel.DataAnnotations;

namespace Rutine.Domain.Metadata
{
    public interface IRutineDetail
    {
        [Required(ErrorMessage = "Required field")]
        int RutineId { get; set; }

        [Required(ErrorMessage = "Required field")]
        int ExerciseId { get; set; }

        DayOfWeek DayOfWeek { get; set; }

        [Required(ErrorMessage = "Required field")]
        int Series { get; set; }

        [Required(ErrorMessage = "Required field")]
        int Reps { get; set; }

        [Required(ErrorMessage = "Required field")]
        decimal Weight { get; set; }
    }
}

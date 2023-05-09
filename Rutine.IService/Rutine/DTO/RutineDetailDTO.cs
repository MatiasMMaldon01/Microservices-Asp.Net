using Rutine.IService.Base.DTO;

namespace Rutine.IService.Rutine.DTO
{
    public class RutineDetailDTO : BaseDTO
    {
        public int ExerciseId { get; set; }

        public string Exercise { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        public string DayOfWeekStr { get; set; }

        public int Series { get; set; }

        public int Reps { get; set; }

        public decimal Weight { get; set; }
    }
}

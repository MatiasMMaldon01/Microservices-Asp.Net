using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Rutine.Domain.Metadata;

namespace Rutine.Domain.Entities
{
    [Table("RoutineDetail")]
    [MetadataType(typeof(IRutineDetail))]
    public class RutineDetail : Base
    {
        public int RutineId { get; set; }

        public int ExerciseId { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        public int Series { get; set; }

        public int Reps { get; set; }

        public int Weight { get; set; }


        public virtual Rutine Rutine { get; set; }
        public virtual Exercise Exercise { get; set; }
    }
}

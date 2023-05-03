using Rutine.Domain.Metadata;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Rutine.Domain.Entities
{
    [Table("Exercise")]
    [MetadataType(typeof(IExercise))]
    public class Exercise : Base
    {
        public string Muscle { get; set; }

        public string Description { get; set; }


        public virtual ICollection<RutineDetail> RutineDetails { get; set; }

    }
}

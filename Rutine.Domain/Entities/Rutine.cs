using Rutine.Domain.Metadata;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rutine.Domain.Entities
{
    [Table("Routine")]
    [MetadataType(typeof(IRutine))]
    public class Rutine : Base
    {
        public string MemberId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }


        public virtual ICollection<RutineDetail> RutineDetails { get; set; }
    }
}

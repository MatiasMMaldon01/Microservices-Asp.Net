using Rutine.IService.Base.DTO;

namespace Rutine.IService.Rutine.DTO
{
    public class RutineDTO : BaseDTO
    {
        public RutineDTO()
        {
            if(RutineDetails == null)
            {
                RutineDetails = new List<RutineDetailDTO>();
            }
        }

        public string MemberId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public List<RutineDetailDTO> RutineDetails { get; set; }
    }
}

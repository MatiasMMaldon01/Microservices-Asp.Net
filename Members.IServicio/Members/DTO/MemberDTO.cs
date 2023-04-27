using Members.IServicio.Base.DTO;

namespace Members.IServicio.Members.DTO
{
    public class MemberDTO : BaseDTO
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }
    }
}

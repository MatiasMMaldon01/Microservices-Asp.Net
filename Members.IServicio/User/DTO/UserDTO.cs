using Members.IServicio.Base.DTO;
using Members.IServicio.Members.DTO;

namespace Members.IServicio.User.DTO
{
    public class UserDTO : BaseDTO
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string MemberId { get; set; }

        public MemberDTO? Member { get; set; }
    }
}

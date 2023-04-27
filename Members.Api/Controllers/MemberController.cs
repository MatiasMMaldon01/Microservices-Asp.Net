using Members.IServicio.Members.DTO;
using Members.IServicio.Members;
using Microsoft.AspNetCore.Mvc;

namespace Members.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;
        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpPost]
        public IResult Create(MemberDTO member)
        {
            var entity = new MemberDTO
            {
                Name = member.Name,
                Surname = member.Surname,
                Email = member.Email,

            };
            _memberService.Create(entity);
            return Results.Ok("Member Succesfully Created");

        }

        [HttpPut]
        public IResult Update(MemberDTO member)
        {
            var entity = new MemberDTO
            {
                Id = member.Id,
                Name = member.Name,
                Surname = member.Surname,
                Email = member.Email,
            };

            _memberService.Update(entity);

            return Results.Ok("Member Succesfully Updated");
        }

        [HttpDelete("{id}")]
        public IResult Delete(string id)
        {
            _memberService.Delete(id);

            return Results.Ok("Member Succesfully Deleted");
        }

        [HttpGet("{id}")]
        public IResult GetById(string id)
        {
            var member = _memberService.GetById(id);

            if (member == null)
            {
                return Results.NotFound("Oopss! No values here");
            }
            else
            {
                return Results.Ok(member);
            }
        }

        [HttpGet]
        public IResult GetByFilter(string? stringToFind)
        {
            if(stringToFind == null) return Results.NotFound("Oopss! No values here");

            var members = _memberService.GetByFilter(stringToFind);

            if (members == null)
            {
                return Results.NotFound();
            }
            else
            {
                return Results.Ok(members);
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public IResult GetAll()
        {
            var members = _memberService.GetAll();

            if (!members.Any())
            {
                return Results.NotFound("Oopss! No values here");
            }
            else
            {
                return Results.Ok(members);
            }
        }
    }
}

using Members.IServicio.User;
using Members.IServicio.User.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Members.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IResult Create(UserDTO user)
        {
            var entity = new UserDTO
            {
                UserName = user.UserName,
                Password = user.Password,
                MemberId = user.MemberId,
            };
            _userService.Create(entity);
            return Results.Ok("User Succesfully Created");

        }

        [HttpPut]
        public IResult Update(UserDTO user)
        {
            var entity = new UserDTO
            {
                Id = user.Id,
                UserName = user.UserName,
                Password = user.Password,
                MemberId = user.MemberId,
            };

            _userService.Update(entity);

            return Results.Ok("User Succesfully Updated");
        }

        [HttpDelete("{id}")]
        public IResult Delete(string id)
        {
            _userService.Delete(id);

            return Results.Ok("User Succesfully Deleted");
        }

        [HttpGet("{id}")]
        public IResult GetById(string id)
        {
            var user = _userService.GetById(id);

            if (user == null)
            {
                return Results.NotFound("Oopss! No values here");
            }
            else
            {
                return Results.Ok(user);
            }
        }

        [HttpGet]
        public IResult GetByFilter(string? stringToFind)
        {
            if (stringToFind == null) return Results.NotFound("Oopss! No values here");

            var users = _userService.GetByFilter(stringToFind);

            if (users == null)
            {
                return Results.NotFound();
            }
            else
            {
                return Results.Ok(users);
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public IResult GetAll()
        {
            var users = _userService.GetAll();

            if (!users.Any())
            {
                return Results.NotFound("Oopss! No values here");
            }
            else
            {
                return Results.Ok(users);
            }
        }
    }
}

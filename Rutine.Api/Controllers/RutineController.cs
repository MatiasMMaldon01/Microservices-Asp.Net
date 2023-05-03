using Microsoft.AspNetCore.Mvc;
using Rutine.IService.Exercise.DTO;
using Rutine.IService.Rutine;
using Rutine.IService.Rutine.DTO;

namespace Rutine.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RutineController : Controller
    {
        private readonly IRutineService _rutineService;

        public RutineController(IRutineService rutineService)
        {
            _rutineService = rutineService;
        }

        [HttpPost]
        public IResult Create(RutineDTO post)
        {
            var rutine = new RutineDTO
            {
                MemberId = post.MemberId,
                StartDate = post.StartDate,
                EndDate = post.EndDate,
                RutineDetails = post.RutineDetails,

            };

            var id = _rutineService.Create(rutine);

            return Results.Ok(id);

        }

        [HttpPut]
        public IResult Update(RutineDTO post)
        {
            var rutine = new RutineDTO
            {
                Id = post.Id,
                MemberId = post.MemberId,
                StartDate = post.StartDate,
                EndDate = post.EndDate,
                RutineDetails = post.RutineDetails
            };

            _rutineService.Update(rutine);

            return Results.Ok(rutine);
        }

        [HttpDelete("{id}")]
        public IResult Delete(int id)
        {
            _rutineService.Delete(id);

            return Results.Ok("Rutine succesfully deleted");
        }

        [HttpGet("{id}")]
        public IResult Get(int id)
        {
            var rutine = _rutineService.Get(id);

            if (rutine == null)
            {
                return Results.NotFound();
            }
            else
            {
                return Results.Ok(rutine);
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public IResult GetAll()
        {
            var request = _rutineService.GetAll();

            if (request == null)
            {
                return Results.NotFound();
            }
            else
            {
                return Results.Ok(request);
            }
        }

        [HttpGet]
        public IResult Get(string? filter)
        {
            var request = _rutineService.Get(filter);

            if (request == null)
            {
                return Results.NotFound();
            }
            else
            {
                return Results.Ok(request);
            }
        }
    }
}

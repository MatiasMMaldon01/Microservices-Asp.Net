using Microsoft.AspNetCore.Mvc;
using Rutine.IService.Exercise;
using Rutine.IService.Exercise.DTO;

namespace Rutine.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExerciseController : Controller
    {
        private readonly IExerciseService _exerciseService;

        public ExerciseController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        [HttpPost]
        public IResult Create(ExerciseDTO post)
        {
            var exercise = new ExerciseDTO
            {
                Description = post.Description,
                Muscle = post.Muscle,
            };

            var id = _exerciseService.Create(exercise);

            return Results.Ok(id);

        }

        [HttpPut]
        public IResult Update(ExerciseDTO post)
        {
            var exercise = new ExerciseDTO 
            { 
                Id = post.Id,
                Description = post.Description, 
                Muscle = post.Muscle 
            };

            return Results.Ok(exercise);
        }

        [HttpDelete("{id}")]
        public IResult Delete(int id)
        {
            _exerciseService.Delete(id);

            return Results.Ok("Exercise succesfully deleted");
        }

        [HttpGet("{id}")]
        public IResult Get(int id)
        {
            var exercise = _exerciseService.Get(id);

            if (exercise == null)
            {
                return Results.NotFound();
            }
            else
            {
                return Results.Ok(exercise);
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public IResult GetAll()
        {
            var request = _exerciseService.GetAll();

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
            var request = _exerciseService.Get(filter);

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

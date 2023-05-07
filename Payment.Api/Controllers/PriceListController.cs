using Microsoft.AspNetCore.Mvc;
using Payment.IService.PriceList;
using Payment.IService.PriceList.DTO;

namespace Payment.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PriceListController : Controller
    {
        private readonly IPriceListService _priceListService;

        public PriceListController(IPriceListService PriceListService)
        {
            _priceListService = PriceListService;
        }

        [HttpPost]
        public IResult Create(PriceListDTO post)
        {
            var priceList = new PriceListDTO
            {
                Amount = post.Amount,
                CreatedAt = post.CreatedAt,

            };

            var id = _priceListService.Create(priceList);

            return Results.Ok(id);

        }

        [HttpPut]
        public IResult Update(PriceListDTO post)
        {
            var priceList = new PriceListDTO
            {
                Id = post.Id,
                Amount = post.Amount,
                CreatedAt = DateTime.Now
            };

            _priceListService.Update(priceList);

            return Results.Ok(priceList);
        }

        [HttpDelete("{id}")]
        public IResult Delete(int id)
        {
            _priceListService.Delete(id);

            return Results.Ok("PriceList succesfully deleted");
        }

        [HttpGet("{id}")]
        public IResult Get(int id)
        {
            var priceList = _priceListService.Get(id);

            if (priceList == null)
            {
                return Results.NotFound();
            }
            else
            {
                return Results.Ok(priceList);
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public IResult GetAll()
        {
            var response = _priceListService.GetAll();

            if (response == null)
            {
                return Results.NotFound();
            }
            else
            {
                return Results.Ok(response);
            }
        }

        [HttpGet]
        public IResult Get(string? filter)
        {
            var response = _priceListService.Get(filter);

            if (response == null)
            {
                return Results.NotFound();
            }
            else
            {
                return Results.Ok(response);
            }
        }

        [HttpGet("GetCurrentPriceList")]
        public IResult GetCurrentPriceList()
        {
            var response = _priceListService.GetCurrentPriceList();

            if (response == null)
            {
                return Results.NotFound();
            }
            else
            {
                return Results.Ok(response);
            }
        }
    }
}

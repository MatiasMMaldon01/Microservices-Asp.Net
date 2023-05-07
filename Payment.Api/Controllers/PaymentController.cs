using Microsoft.AspNetCore.Mvc;
using Payment.IService.Payment;
using Payment.IService.Payment.DTO;

namespace Payment.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;   
        }

        [HttpPost]
        public IResult Create(PaymentDTO post)
        {
            var payment = new PaymentDTO
            {
                Amount = post.Amount,
                PayDate = post.PayDate,
                MemberId = post.MemberId,
                PriceListId = post.PriceListId,

            };

            var id = _paymentService.Create(payment);

            return Results.Ok(id);

        }

        [HttpPut]
        public IResult Update(PaymentDTO post)
        {
            var payment = new PaymentDTO
            {
                Id = post.Id,
                Amount = post.Amount,
                PayDate = post.PayDate,
                MemberId = post.MemberId,
                PriceListId = post.PriceListId,
            };

            _paymentService.Update(payment);

            return Results.Ok(payment);
        }

        [HttpDelete("{id}")]
        public IResult Delete(int id)
        {
            _paymentService.Delete(id);

            return Results.Ok("Payment succesfully deleted");
        }

        [HttpGet("{id}")]
        public IResult Get(int id)
        {
            var payment = _paymentService.Get(id);

            if (payment == null)
            {
                return Results.NotFound();
            }
            else
            {
                return Results.Ok(payment);
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public IResult GetAll()
        {
            var response = _paymentService.GetAll();

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
            var response = _paymentService.Get(filter);

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

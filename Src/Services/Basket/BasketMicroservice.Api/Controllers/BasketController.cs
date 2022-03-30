using BasketMicroservice.Api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasketMicroservice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _basketRepository;

        public BasketController(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }


        [HttpGet("GetBasket")]
        public async Task<IActionResult> GetBasket([FromQuery]string userName)
        {
            var basket = await _basketRepository.Get(userName);
            return Ok(basket);
        }

        [HttpPost("UpdateBasket")]
        public async Task<IActionResult> UpdateBasket(Entities.ShoppingCart basket)
        {
            await _basketRepository.UpdateBasket(basket);

            return Ok();
        }

        [HttpPost("DeleteBasket")]
        public async Task<IActionResult> DeleteBasket(string userName)
        {
            await _basketRepository.DeleteBasket(userName);

            return Ok();
        }
    }
}

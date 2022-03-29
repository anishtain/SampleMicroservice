using BasketMicroservice.Api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasketMicroservice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly Repositories.IBasketRepository repository;

        public BasketController(IBasketRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("GetBasket")]
        public async Task<IActionResult> GetBasket([FromQuery]string userName)
        {
            var basket = await repository.Get(userName);
             return Ok(basket);
        }

        [HttpPost("UpdateBasket")]
        public async Task<IActionResult> UpdateBasket([FromBody]Entities.ShoppingCart basket)
        {
            await repository.UpdateBasket(basket);

            return Ok();
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteBasket([FromQuery]string userName)
        {
            await repository.DeleteBasket(userName);

            return Ok();
        }
    }
}

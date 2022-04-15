using Discount.Api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Discount.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountRepository _discountRepository;

        public DiscountController(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }

        [HttpGet("GetDiscount")]
        public async Task<IActionResult> GetDiscount(string productName)
        {
            var coupon = await _discountRepository.GetCoupon(productName);

            return Ok(coupon);
        }

        [HttpPost("CreateCoupon")]
        public async Task<IActionResult> CreateCoupon([FromBody]Entites.Coupon coupon)
        {
            var response = await _discountRepository.CreateCoupon(coupon);

            return Ok(response);
        }

        [HttpPost("UpdateCoupon")]
        public async Task<IActionResult> UpdateCoupon([FromBody] Entites.Coupon coupon)
        {
            var response = await _discountRepository.UpdateCoupon(coupon);

            return Ok(response);
        }

        [HttpPost("DeleteCoupon")]
        public async Task<IActionResult> DeleteCoupon(string productName)
        {
            var response = await _discountRepository.DeleteProduct(productName);

            return Ok(response);
        }
    }
}

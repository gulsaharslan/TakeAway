using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TakeAway.Discount.Dtos;
using TakeAway.Discount.Services;

namespace TakeAway.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountCouponService _discountCouponService;

        public DiscountController(IDiscountCouponService discountCouponService)
        {
            _discountCouponService = discountCouponService;
        }

        [HttpGet]
        public async Task<IActionResult> DiscountCouponList() 
        {
            var values = await _discountCouponService.GetDiscountCouponAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscountCoupon(CreateDiscountCouponDto createDiscountCouponDto)
        {
            await _discountCouponService.CreateDiscountCouponAsync(createDiscountCouponDto);
            return Ok("Kupon eklendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDiscountCoupon(int id)
        {
            await _discountCouponService.DeleteDiscountCouponAsync(id);
            return Ok("Kupon silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDiscountCoupon(UpdateDiscountCouponDto updateDiscountCouponDto)
        {
            await _discountCouponService.UpdateDiscountCouponAsync(updateDiscountCouponDto);
            return Ok("Kupon güncellendi");
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetDiscountCoupon(int id)
        {
            var value = await _discountCouponService.GetByIdDiscountCouponAsync(id);
            return Ok(value);
        }
    }
}

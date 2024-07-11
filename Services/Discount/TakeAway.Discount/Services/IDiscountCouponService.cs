using TakeAway.Discount.Dtos;

namespace TakeAway.Discount.Services
{
    public interface IDiscountCouponService
    {
        Task<List<ResultDiscountCouponDto>> GetDiscountCouponAsync();
        Task CreateDiscountCouponAsync(CreateDiscountCouponDto createDiscountCouponDto);
        Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateDiscountCouponDto);
        Task DeleteDiscountCouponAsync(int id);
        Task <GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int id);
    }
}

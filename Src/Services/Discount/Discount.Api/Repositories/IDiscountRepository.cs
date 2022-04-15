using Discount.Api.Entites;

namespace Discount.Api.Repositories
{
    public interface IDiscountRepository
    {
        Task<bool> CreateCoupon(Coupon coupon);
        Task<bool> DeleteProduct(string productName);
        Task<Coupon> GetCoupon(string productName);
        Task<bool> UpdateCoupon(Coupon coupon);
    }
}
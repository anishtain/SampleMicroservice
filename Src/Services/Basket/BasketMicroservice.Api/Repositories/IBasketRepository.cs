using BasketMicroservice.Api.Entities;

namespace BasketMicroservice.Api.Repositories
{
    public interface IBasketRepository
    {
        Task DeleteBasket(string userName);
        Task<ShoppingCart> Get(string userName);
        Task UpdateBasket(ShoppingCart basket);
    }
}
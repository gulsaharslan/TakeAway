using TakeAway.Baskett.Dtos;

namespace TakeAway.Baskett.Services
{
    public interface IBasketService
    {
        Task<BasketTotalDto> GetBasket(string UserId);
        Task SaveBasket (BasketTotalDto basket);
        Task DeleteBasket (string UserId);
    }
}

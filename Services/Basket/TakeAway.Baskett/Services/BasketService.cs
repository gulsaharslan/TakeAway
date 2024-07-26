using TakeAway.Baskett.Dtos;

namespace TakeAway.Baskett.Services
{
    public class BasketService : IBasketService
    {
        public Task DeleteBasket(string UserId)
        {
            throw new NotImplementedException();
        }

        public Task<BasketTotalDto> GetBasket(string UserId)
        {
            throw new NotImplementedException();
        }

        public Task SaveBasket(BasketTotalDto basket)
        {
            throw new NotImplementedException();
        }
    }
}

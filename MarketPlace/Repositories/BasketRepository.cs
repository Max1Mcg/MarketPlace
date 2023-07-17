using MarketPlace.Contexts;
using MarketPlace.Models;
using MarketPlace.Repositories.Interfaces;
namespace MarketPlace.Repositories
{
    public class BasketRepository:IBasketRepository
    {
        MarketPlaceContext _context;
        public BasketRepository(MarketPlaceContext context)
        {
            _context = context;
        }
        public async Task CreateBasket(Basket basket)
        {
            _context.Baskets.Add(basket);
            await _context.SaveChangesAsync();
        }
        public Basket GetBasket(Guid id)
        {
            return _context.Baskets.FirstOrDefault(b => b.Idbasket == id);
        }
    }
}

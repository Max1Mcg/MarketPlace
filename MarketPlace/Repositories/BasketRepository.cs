using MarketPlace.Contexts;
using MarketPlace.Models;
using MarketPlace.Repositories.Base;
using MarketPlace.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Repositories
{
    public class BasketRepository:BaseRepository<Basket>, IBasketRepository
    {
        //private readonly MarketPlaceContext _context;
        public BasketRepository(MarketPlaceContext context):base(context)
        {
            //_context = context;
        }
        /*public async Task CreateBasket(Basket basket)
        {
            _context.Baskets.Add(basket);
            await _context.SaveChangesAsync();
        }*/
        public Basket GetBasket(Guid id)
        {
            return _context.Baskets
                .Where(b => b.Idbasket == id)
                .Include(b => b.Items)
                .Include(b => b.User)
                .SingleOrDefault();
        }
    }
}

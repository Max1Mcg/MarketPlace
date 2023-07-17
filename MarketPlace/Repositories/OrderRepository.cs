using MarketPlace.Contexts;
using MarketPlace.Models;
using MarketPlace.Repositories.Interfaces;

namespace MarketPlace.Repositories
{
    public class OrderRepository:IOrderRepository
    {
        MarketPlaceContext _context;
        public OrderRepository(MarketPlaceContext context)
        {
            _context = context;
        }
        public async Task CreateOrder(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }
        public Order GetOrder(Guid id)
        {
            return _context.Orders.FirstOrDefault(o => o.Idorder == id);
        }
    }
}

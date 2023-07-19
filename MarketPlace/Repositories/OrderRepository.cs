using MarketPlace.Contexts;
using MarketPlace.Models;
using MarketPlace.Repositories.Base;
using MarketPlace.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Repositories
{
    public class OrderRepository:BaseRepository<Order>, IOrderRepository
    {
        //private readonly MarketPlaceContext _context;
        public OrderRepository(MarketPlaceContext context):base(context)
        {
            //_context = context;
        }
        /*public async Task CreateOrder(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }*/
        public Order GetOrder(Guid id)
        {
            return _context.Orders
                .Where(o => o.Idorder == id)
                .Include(o => o.Status)
                .Include(o => o.Basket)
                .Include(o => o.Delivery)
                .SingleOrDefault(o => o.Idorder == id);
        }
    }
}

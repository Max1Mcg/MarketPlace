using MarketPlace.Contexts;
using MarketPlace.Models;
using MarketPlace.Repositories.Base;
using MarketPlace.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Repositories
{
    public class OrderRepository:BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(MarketPlaceContext context):base(context)
        {
        }
        public Order GetOrder(Guid id)
        {
            return _context.Orders
                .Where(o => o.Idorder == id)
                .Include(o => o.Status)
                .Include(o => o.Basket)
                    .ThenInclude(b => b.User)
                .Include(o => o.Delivery)
                .Include(o => o.receipt)
                .SingleOrDefault(o => o.Idorder == id);
        }
    }
}

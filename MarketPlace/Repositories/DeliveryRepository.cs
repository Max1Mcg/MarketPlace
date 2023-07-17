using MarketPlace.Contexts;
using MarketPlace.Models;
using MarketPlace.Repositories.Interfaces;

namespace MarketPlace.Repositories
{
    public class DeliveryRepository : IDeliveryRepository
    {
        MarketPlaceContext _context;
        public DeliveryRepository(MarketPlaceContext context)
        {
            _context = context;
        }
        public async Task CreateDelivery(Delivery delivery)
        {
            _context.Deliveries.Add(delivery);
            await _context.SaveChangesAsync();
        }
        public IEnumerable<Delivery> GetDeliveries()
        {
            return _context.Deliveries;
        }
    }
}

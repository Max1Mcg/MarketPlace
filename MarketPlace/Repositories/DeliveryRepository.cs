using MarketPlace.Contexts;
using MarketPlace.Models;
using MarketPlace.Repositories.Base;
using MarketPlace.Repositories.Interfaces;

namespace MarketPlace.Repositories
{
    public class DeliveryRepository :BaseRepository<Delivery>, IDeliveryRepository
    {
        public DeliveryRepository(MarketPlaceContext context):base(context)
        {
        }
        public IEnumerable<Delivery> GetDeliveries()
        {
            return _context.Deliveries;
        }
        public Delivery GetDelivery(int id)
        {
            return _context.Deliveries.FirstOrDefault(d => d.Iddelivery == id);
        }
    }
}

using MarketPlace.Models;

namespace MarketPlace.Repositories.Interfaces
{
    public interface IDeliveryRepository
    {
        public Task CreateDelivery(Delivery delivery);
        public IEnumerable<Delivery> GetDeliveries();
        public Delivery GetDelivery(int id);
    }
}

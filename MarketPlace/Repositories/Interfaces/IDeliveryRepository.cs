using MarketPlace.Models;

namespace MarketPlace.Repositories.Interfaces
{
    public interface IDeliveryRepository : IBaseRepository<Delivery>
    {
        public IEnumerable<Delivery> GetDeliveries();
        public Delivery GetDelivery(int id);
    }
}

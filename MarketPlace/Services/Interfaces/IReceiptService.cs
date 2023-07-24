using MarketPlace.Models;

namespace MarketPlace.Services.Interfaces
{
    public interface IReceiptService
    {
        public Receipt GetReceipt(Guid id);
        public Task Payment(Guid id);
    }
}

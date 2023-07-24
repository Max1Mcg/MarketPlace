using MarketPlace.Models;

namespace MarketPlace.Repositories.Interfaces
{
    public interface IReceiptRepository:IBaseRepository<Receipt>
    {
        public Receipt GetReceipt(Guid id);
    }
}

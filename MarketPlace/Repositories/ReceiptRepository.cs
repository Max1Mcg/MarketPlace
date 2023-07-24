using MarketPlace.Contexts;
using MarketPlace.Models;
using MarketPlace.Repositories.Base;
using MarketPlace.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Repositories
{
    public class ReceiptRepository: BaseRepository<Receipt>, IReceiptRepository
    {
        public ReceiptRepository(MarketPlaceContext context) : base(context)
        {
        }
        public Receipt GetReceipt(Guid id)
        {
            return _context.Receipt
                .Where(r => r.Idreceipt == id)
                .Include(r => r.Orders)
                .SingleOrDefault();
        }
    }
}

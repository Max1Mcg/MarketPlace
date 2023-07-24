using MarketPlace.Models;
using MarketPlace.Repositories.Interfaces;
using MarketPlace.Services.Interfaces;

namespace MarketPlace.Services
{
    public class ReceiptService:IReceiptService
    {
        IReceiptRepository _receiptRepository;
        public ReceiptService(IReceiptRepository receiptRepository)
        {
            _receiptRepository = receiptRepository;
        }
        public Receipt GetReceipt(Guid id)
        {
            return _receiptRepository.GetReceipt(id);
        }
        /// <summary>
        /// Оплата счёта.
        /// </summary>
        /// <param name="id">id счёта</param>
        /// <returns></returns>
        public async Task Payment(Guid id)
        {
            var receipt = GetReceipt(id);
            receipt.hasPayment= true;
            await _receiptRepository.Update(receipt);
        }
    }
}

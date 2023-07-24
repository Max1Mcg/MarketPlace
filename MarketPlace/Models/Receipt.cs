using System.ComponentModel.DataAnnotations;

namespace MarketPlace.Models
{
    public partial class Receipt
    {
        [Key]
        public Guid Idreceipt { get; set; }
        public double? Cost { get; set; }
        public bool hasPayment { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}

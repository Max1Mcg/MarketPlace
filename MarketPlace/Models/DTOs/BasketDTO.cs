namespace MarketPlace.Models.DTOs
{
    public class BasketDTO
    {
        public Guid Userid { get; set; }

        public int? ItemCount { get; set; }

        public double? SummaryCost { get; set; }

        public DateTime? UpdatedAt { get; set; }
        public virtual ICollection<Guid> ItemsIds { get; set; } = new List<Guid>();
    }
}
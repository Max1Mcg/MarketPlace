namespace MarketPlace.Models.DTOs
{
    public class ItemDTO
    {
        public Guid Userid { get; set; }
        public double? Cost { get; set; }
        public string? Description { get; set; }
        public string? Weight { get; set; }
        public bool? Sold { get; set; }
        public virtual ICollection<int> Categories { get; set; } = new List<int>();
    }
}

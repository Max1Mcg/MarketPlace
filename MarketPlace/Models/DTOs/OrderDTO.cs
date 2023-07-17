namespace MarketPlace.Models.DTOs
{
    public class OrderDTO
    {
        public int Statusid { get; set; }

        public Guid Basketid { get; set; }

        public int Deliveryid { get; set; }

        public string? AdditionalInformation { get; set; }

        public DateTime? FormedAt { get; set; }

        public DateTime? ClosedAt { get; set; }
    }
}

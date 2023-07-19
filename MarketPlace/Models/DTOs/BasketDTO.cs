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
/*
{
  "userid": "194a7f70-fb0e-4d2d-922f-9b5ba8d072d4",
  "itemCount": 0,
  "summaryCost": 0,
  "updatedAt": "2023-07-18T09:08:53.141Z",
  "itemsIds": [
    "3ceb837d-b313-4874-9b40-7801a102836d",
"f30a8ee3-4967-4220-bc5e-724f310523a8"
  ]
}
*/
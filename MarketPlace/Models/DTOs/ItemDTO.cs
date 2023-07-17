﻿namespace MarketPlace.Models.DTOs
{
    public class ItemDTO
    {
        public double? Cost { get; set; }
        public string? Description { get; set; }
        public string? Weight { get; set; }
        public bool? Sold { get; set; }
        //public ICollection<Category> Categories { get; set; } = new List<Category>();
    }
}

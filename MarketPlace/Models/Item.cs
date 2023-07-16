using System;
using System.Collections.Generic;

namespace MarketPlace.Models;

public partial class Item
{
    public Guid Iditem { get; set; }

    public double? Cost { get; set; }

    public string? Description { get; set; }

    public string? Weight { get; set; }

    public bool? Sold { get; set; }

    public virtual ICollection<Basket> Baskets { get; set; } = new List<Basket>();

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
}

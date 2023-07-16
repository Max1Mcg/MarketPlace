using System;
using System.Collections.Generic;

namespace MarketPlace.Models;

public partial class Basket
{
    public Guid Idbasket { get; set; }

    public Guid Userid { get; set; }

    public int? ItemCount { get; set; }

    public double? SummaryCost { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual User User { get; set; } = null!;

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}

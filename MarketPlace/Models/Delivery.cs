using System;
using System.Collections.Generic;

namespace MarketPlace.Models;

public partial class Delivery
{
    public int Iddelivery { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}

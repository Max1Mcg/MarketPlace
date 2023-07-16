using System;
using System.Collections.Generic;

namespace MarketPlace.Models;

public partial class Status
{
    public int Idstatus { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}

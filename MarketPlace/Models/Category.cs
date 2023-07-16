using System;
using System.Collections.Generic;

namespace MarketPlace.Models;

public partial class Category
{
    public int Idcategory { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}

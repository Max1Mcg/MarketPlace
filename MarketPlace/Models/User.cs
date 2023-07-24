using System;
using System.Collections.Generic;

namespace MarketPlace.Models;

public partial class User
{
    public Guid Iduser { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Patronymic { get; set; }

    public int? Age { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }
    public string? Role { get; set; }
    public virtual ICollection<Basket> Baskets { get; set; } = new List<Basket>();
    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}

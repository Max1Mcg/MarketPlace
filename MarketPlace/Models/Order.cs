using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Models;

public partial class Order
{
    public Guid Idorder { get; set; }

    public int Statusid { get; set; }

    public Guid Basketid { get; set; }

    public int Deliveryid { get; set; }

    public string? AdditionalInformation { get; set; }

    public DateTime? FormedAt { get; set; }

    public DateTime? ClosedAt { get; set; }
    public Guid? Receiptid { get; set; }

    public virtual Basket Basket { get; set; } = null!;

    public virtual Delivery Delivery { get; set; } = null!;

    public virtual Status Status { get; set; } = null!;
    public virtual Receipt? receipt { get; set; }
}

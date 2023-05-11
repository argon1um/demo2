using System;
using System.Collections.Generic;

namespace demo2.Models;

public partial class Delivery
{
    public int Delivid { get; set; }

    public string? Delivname { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}

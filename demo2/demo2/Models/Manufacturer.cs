using System;
using System.Collections.Generic;

namespace demo2.Models;

public partial class Manufacturer
{
    public int Manufid { get; set; }

    public string? Manufname { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}

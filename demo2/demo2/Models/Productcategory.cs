using System;
using System.Collections.Generic;

namespace demo2.Models;

public partial class Productcategory
{
    public int Categoryid { get; set; }

    public string? Categoryname { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}

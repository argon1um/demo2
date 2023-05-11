using System;
using System.Collections.Generic;

namespace demo2.Models;

public partial class Product
{
    public string Productarticul { get; set; } = null!;

    public string? Productname { get; set; }

    public string? Productunit { get; set; }

    public decimal? Productprice { get; set; }

    public decimal? Productmaxdiscount { get; set; }

    public int? Productmanufid { get; set; }

    public int? Productdelivid { get; set; }

    public int? Proudctcategory { get; set; }

    public decimal? Productdiscount { get; set; }

    public int? Productcount { get; set; }

    public string? Productdescription { get; set; }

    public string? Productimage { get; set; }

    public virtual Delivery? Productdeliv { get; set; }

    public virtual Manufacturer? Productmanuf { get; set; }

    public virtual Productcategory? ProudctcategoryNavigation { get; set; }
}

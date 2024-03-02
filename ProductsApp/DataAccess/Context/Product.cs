using System;
using System.Collections.Generic;

namespace ProductsApp.DataAccess.Context;

public partial class Product
{
    public int Id { get; set; }

    public string? ProductName { get; set; }

    public decimal? Cost { get; set; }
}

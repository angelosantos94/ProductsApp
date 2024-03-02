using System;
using System.Collections.Generic;

namespace ProductsApp.DataAccess.Context;

public partial class Transaction
{
    public string? TransactionId { get; set; }

    public int? ProductId { get; set; }

    public decimal? Cost { get; set; }

    public int? Quantity { get; set; }

    public decimal? Amount { get; set; }

    public decimal? TotalAmount { get; set; }

    public decimal? Cash { get; set; }

    public decimal? Change { get; set; }
}

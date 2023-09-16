using System;
using System.Collections.Generic;

namespace MehmetCIL_Odev1.Models;

public partial class OrderSubtotal
{
    public int OrderId { get; set; }

    public decimal? Subtotal { get; set; }
}

using System;
using System.Collections.Generic;

namespace Small_Sales_System.Models
{
    public partial class Conceptos
    {
        public long Id { get; set; }
        public long? IdVentas { get; set; }
        public int? Cantidad { get; set; }
        public long? IdProductos { get; set; }
        public decimal? Precio { get; set; }

        public virtual Productos IdProductosNavigation { get; set; }
        public virtual Ventas IdVentasNavigation { get; set; }
    }
}

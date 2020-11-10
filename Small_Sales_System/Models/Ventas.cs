using System;
using System.Collections.Generic;

namespace Small_Sales_System.Models
{
    public partial class Ventas
    {
        public Ventas()
        {
            Conceptos = new HashSet<Conceptos>();
        }

        public long Id { get; set; }
        public long? IdCliente { get; set; }
        public DateTime? Fecha { get; set; }
        public decimal? Total { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual ICollection<Conceptos> Conceptos { get; set; }
    }
}

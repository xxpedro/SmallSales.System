using System;
using System.Collections.Generic;

namespace Small_Sales_System.Models
{
    public partial class Productos
    {
        public Productos()
        {
            Conceptos = new HashSet<Conceptos>();
        }

        public long Id { get; set; }
        public string Marca { get; set; }
        public int? IdTipo { get; set; }
        public decimal? Precio { get; set; }
        public DateTime? FechaRegistro { get; set; }

        public virtual TipoProducto IdTipoNavigation { get; set; }
        public virtual ICollection<Conceptos> Conceptos { get; set; }
    }
}

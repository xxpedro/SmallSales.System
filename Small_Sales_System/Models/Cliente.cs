using System;
using System.Collections.Generic;

namespace Small_Sales_System.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Ventas = new HashSet<Ventas>();
        }

        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Numero { get; set; }
        public string Correo { get; set; }
        public DateTime? FechaRegistro { get; set; }

        public virtual ICollection<Ventas> Ventas { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Small_Sales_System.Models.Request
{
    public class ConceptosRQ
    {
        public int cantidad { get; set; }
        public int idProducto {get; set; }
        public decimal Precio { get; set; }
    }
}

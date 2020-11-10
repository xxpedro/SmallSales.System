using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Small_Sales_System.Models.Request
{
    public class VentasRQ
    {
        public long idCliente { get; set; }

        public List<ConceptosRQ> conceptos { get; set; }

    }
}

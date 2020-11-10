using Small_Sales_System.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Small_Sales_System.Models.ViewModel
{
    public class VentasViewModel
    {
        public long? IdCliente { get; set; }
        public DateTime? Fecha { get; set; }
        public List<ConceptosRQ> conceptos { get; set; }
    }
}
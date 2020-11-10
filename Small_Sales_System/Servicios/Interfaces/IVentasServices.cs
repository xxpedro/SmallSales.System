using Small_Sales_System.Models;
using Small_Sales_System.Models.Request;
using Small_Sales_System.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Small_Sales_System.Servicios.Interfaces
{
    public interface IVentasServices
    {
        public void HacerVentas(VentasRQ model);
        public List<Ventas> Listar();
        public List<Ventas> ListarID(int id);
        public void Delete(int id);
        public Ventas Editar(int id, VentasViewModel venta);

    }
}

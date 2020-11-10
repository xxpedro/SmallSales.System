using Small_Sales_System.Models;
using Small_Sales_System.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Small_Sales_System.Servicios.Interfaces
{
    public interface ITipoProductoServices
    {
        public void Create(TipoProductoViewModel model);
        public List<TipoProducto>Listar();
        public List<TipoProducto> ListarID(int id);
        public void Eliminar(int id);
        public void Editar(TipoProductoViewModel model, int id);

    }
}

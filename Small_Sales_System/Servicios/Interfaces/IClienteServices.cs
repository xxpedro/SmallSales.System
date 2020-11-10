using Small_Sales_System.Models;
using Small_Sales_System.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Small_Sales_System.Servicios.Interfaces
{
    public interface IClienteServices
    {
        public void Agregar(ClienteViewModel model);
        public List<Cliente> lista();
        public List<Cliente> ListarID(int id);
        public void Eliminar(int id);
        public void Editar(int id, ClienteViewModel model);
    }
}

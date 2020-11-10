using Small_Sales_System.Models;
using Small_Sales_System.Models.Request;
using Small_Sales_System.Models.Response;
using Small_Sales_System.Models.ViewModel;
using System.Collections.Generic;


namespace Small_Sales_System.Servicios.Interfaces
{
    public interface IUsuariosServices
    {
        public UsuarioResponse Logueo(AutenticarRQ model);
        public List<Usuarios> Listar();
        public void Create(UsuariosViewModel model);
        public List<Usuarios> ListarID(int Id);
        public void Editar(int id, UsuariosViewModel model);
        public void Eliminar(int id);
    }
}

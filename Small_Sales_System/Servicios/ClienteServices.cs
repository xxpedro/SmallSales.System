using Microsoft.AspNetCore.Http;
using Small_Sales_System.Models;
using Small_Sales_System.Models.ViewModel;
using Small_Sales_System.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Small_Sales_System.Servicios
{
    public class ClienteServices : IClienteServices
    {
        public void Agregar(ClienteViewModel model)
        {
            try
            {
                using (Small_Sales_SystemContext db = new Small_Sales_SystemContext())
                {
                    Cliente clientes = new Cliente();
                    clientes.Nombre = model.Nombre;
                    clientes.Apellido = model.Apellido;
                    clientes.Numero = model.Numero;
                    clientes.Correo = model.Correo;
                    clientes.FechaRegistro = DateTime.Today;
                    db.Cliente.Add(clientes);
                    db.SaveChanges();


                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Editar(int id, ClienteViewModel model)
        {
            try
            {
                using (Small_Sales_SystemContext db = new Small_Sales_SystemContext())
                {
                    var EditarClientes = db.Cliente.Where(x=>x.Id ==id).FirstOrDefault();
                    EditarClientes.Nombre = model.Nombre;
                    EditarClientes.Apellido = model.Apellido;
                    EditarClientes.Correo = model.Correo;
                    EditarClientes.Numero = model.Numero;
                    db.SaveChanges();

                }
            }
            catch (Exception ex)
            {
               
                throw ex;
            }
        }
        public void Eliminar(int id)
        {
            try
            {
                using (Small_Sales_SystemContext db = new Small_Sales_SystemContext())
                {
                    var EliminarCliente = db.Cliente.Where(x => x.Id == id).FirstOrDefault();
                    db.Cliente.Remove(EliminarCliente);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<Cliente> lista()
        {
            try
            {
                List<Cliente> lista;
                using (Small_Sales_SystemContext db = new Small_Sales_SystemContext())
                {
                    lista = db.Cliente.ToList();
                }
                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Cliente> ListarID(int id)
        {
            try
            {
                List<Cliente> lista;
                using (Small_Sales_SystemContext db = new Small_Sales_SystemContext())
                {
                    lista = db.Cliente.Where(x => x.Id == id).ToList();
                }
                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

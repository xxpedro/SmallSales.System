using Small_Sales_System.Models;
using Small_Sales_System.Models.ViewModel;
using Small_Sales_System.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Small_Sales_System.Servicios
{
    public class TipoProductoServices : ITipoProductoServices
    {
        public void Create(TipoProductoViewModel model)
        {
            try
            {
                using (Small_Sales_SystemContext db = new Small_Sales_SystemContext())
                {
                    TipoProducto tipo = new TipoProducto();
                    tipo.Nombre = model.Nombre;
                    db.TipoProducto.Add(tipo);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Editar(TipoProductoViewModel model, int id)
        {
            try
            {
                using (Small_Sales_SystemContext db = new Small_Sales_SystemContext())
                {
                    var EditarTipo = db.TipoProducto.Where(x => x.Id == id).FirstOrDefault();
                    EditarTipo.Nombre = model.Nombre;
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
                    var EditarTipo = db.TipoProducto.Where(x => x.Id == id).FirstOrDefault();
                    db.Remove(EditarTipo);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<TipoProducto> Listar()
        {
            try
            {
                List<TipoProducto> Lista;
                using (Small_Sales_SystemContext db = new Small_Sales_SystemContext())
                {
                    Lista = db.TipoProducto.ToList();
                }
                return Lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<TipoProducto> ListarID(int id)
        {
            try
            {
                List<TipoProducto> Lista;
                using (Small_Sales_SystemContext db = new Small_Sales_SystemContext())
                {
                    Lista = db.TipoProducto.Where(x => x.Id == id).ToList() ;
                }
                return Lista;
            }
            catch (Exception)
            {

                throw;
            }
        }



    }
}

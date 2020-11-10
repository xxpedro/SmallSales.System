using Small_Sales_System.Models;
using Small_Sales_System.Models.ViewModel;
using Small_Sales_System.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Small_Sales_System.Servicios
{
    public class ProductosServices : IProductosServices
    {

        public void Agregar(ProductosViewModel model)
        {
            using (Small_Sales_SystemContext db = new Small_Sales_SystemContext()) 
            {
                try
                {
                    Productos productos = new Productos();
                    productos.FechaRegistro = DateTime.Today;
                    productos.IdTipo = model.IdTipo;
                    productos.Marca = model.Marca;
                    productos.Precio = model.Precio;
                    db.Productos.Add(productos);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public void Editar(int id, ProductosViewModel model)
        {
            using (Small_Sales_SystemContext db = new Small_Sales_SystemContext())
            {
                var EditarProducto = db.Productos.Where(x=>x.Id ==id).FirstOrDefault();
                EditarProducto.Marca = model.Marca;
                EditarProducto.Precio = model.Precio;
                EditarProducto.IdTipo = model.IdTipo;
                db.SaveChanges();
            }
        }

        public void Eliminar(int id)
        {
            try
            {
                using (Small_Sales_SystemContext db = new Small_Sales_SystemContext())
                {
                    var EditarProducto = db.Productos.Where(x => x.Id == id).FirstOrDefault();
                    db.Productos.Remove(EditarProducto);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Productos> lista()
        {
            try
            {
                List<Productos> lista;
                using (Small_Sales_SystemContext db = new Small_Sales_SystemContext())
                {
                    lista = db.Productos.ToList();
                }
                return lista;
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public List<Productos> ListarID(int id)
        {
            try
            {
                List<Productos> lista;
                using (Small_Sales_SystemContext db = new Small_Sales_SystemContext())
                {
                    lista = db.Productos.Where(x=>x.Id == id).ToList();
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

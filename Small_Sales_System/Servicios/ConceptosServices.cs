using Small_Sales_System.Models;
using Small_Sales_System.Models.ViewModel;
using Small_Sales_System.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Small_Sales_System.Servicios
{
    public class ConceptosServices : IConceptosServices
    {
       
        public void Editar(int id, ConceptosViewModel model)
        {
            try
            {
                using (Small_Sales_SystemContext db = new Small_Sales_SystemContext())
                {
                    var eliminar = db.Conceptos.Where(x => x.Id == id).FirstOrDefault();
                    eliminar.Cantidad = model.Cantidad;
                    eliminar.IdVentas = model.IdVentas;
                    eliminar.Precio = model.Precio;
                    eliminar.IdProductos = model.IdProductos;
                    db.SaveChanges();
                }
            }
            catch (Exception exp)
            {

                throw exp;
            }
        }

        public void Eliminar(int id)
        {
            try
            {
                using (Small_Sales_SystemContext db = new Small_Sales_SystemContext())
                {
                    var eliminar = db.Conceptos.Where(x => x.Id == id).FirstOrDefault();
                    db.Conceptos.Remove(eliminar);
                    db.SaveChanges();

                }
            }
            catch (Exception exp)
            {

                throw exp;
            }
        }

        public List<Conceptos> lista()
        {
            try
            {
                List<Conceptos> lista;
                using (Small_Sales_SystemContext db = new Small_Sales_SystemContext())
                {
                    lista = db.Conceptos.ToList();

                }
                return lista;
            }
            catch (Exception exp)
            {

                throw exp;
            }
        }

        public List<Conceptos> ListarID(int id)
        {
            try
            {
                List<Conceptos> lista;
                using (Small_Sales_SystemContext db = new Small_Sales_SystemContext())
                {
                    lista = db.Conceptos.Where(x=>x.Id == id).ToList();
                }
                return lista;
            }
            catch (Exception exp)
            {

                throw exp;
            }
        }
    }
}


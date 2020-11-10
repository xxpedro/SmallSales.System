using Small_Sales_System.Models;
using Small_Sales_System.Models.Request;
using Small_Sales_System.Models.ViewModel;
using Small_Sales_System.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Small_Sales_System.Servicios
{
    public class VentasServices : IVentasServices
    {


        public void HacerVentas(VentasRQ model)
        {
            try
            {
                using (Small_Sales_SystemContext db = new Small_Sales_SystemContext())
                {
                    Ventas ventas = new Ventas();
                    ventas.IdCliente = model.idCliente;
                    ventas.Total = model.conceptos.Sum(x => x.cantidad * x.Precio);
                    ventas.Fecha = DateTime.Now;
                    db.Ventas.Add(ventas);
                    db.SaveChanges();

                    foreach (var conceptos in model.conceptos)
                    {
                        Conceptos concepto = new Conceptos();
                        concepto.Cantidad = conceptos.cantidad;
                        concepto.IdProductos = conceptos.idProducto;
                        concepto.IdVentas = ventas.Id;
                        concepto.Precio = concepto.Precio;
                        db.Conceptos.Add(concepto);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Ventas> Listar()
        {
            try
            {
                List<Ventas> ListarVentas;
                using (Small_Sales_SystemContext db = new Small_Sales_SystemContext())
                {
                    ListarVentas = db.Ventas.ToList();
                }
                return ListarVentas;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<Ventas> ListarID(int id)
        {
            try
            {
                List<Ventas> ListarVentas;
                using (Small_Sales_SystemContext db = new Small_Sales_SystemContext())
                {
                    ListarVentas = db.Ventas.Where(x => x.Id == id).ToList();
                }
                return ListarVentas;

            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        public void Delete(int id)
        {
            try
            {
                using (Small_Sales_SystemContext db = new Small_Sales_SystemContext())
                {
                    var EliminarVentas = db.Ventas.Where(x => x.Id == id).FirstOrDefault();
                    db.Ventas.Remove(EliminarVentas);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Ventas Editar(int id, VentasViewModel venta)
        {
            try
            {
                Ventas EditarVentas = new Ventas();
                using (Small_Sales_SystemContext db = new Small_Sales_SystemContext())
                {
                    EditarVentas = db.Ventas.Where(x => x.Id == id).FirstOrDefault();
                    EditarVentas.IdCliente = venta.IdCliente;
                    EditarVentas.Fecha = venta.Fecha;
                    EditarVentas.Total = venta.conceptos.Sum(x => x.cantidad * x.Precio);
                    db.SaveChanges();
                }
                return EditarVentas;
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }
    }
}

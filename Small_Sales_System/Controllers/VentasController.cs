using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Small_Sales_System.Models;
using Small_Sales_System.Models.Request;
using Small_Sales_System.Models.ViewModel;
using Small_Sales_System.Servicios.Interfaces;

namespace Small_Sales_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VentasController : ControllerBase
    {

        private readonly IVentasServices ventasServices;

        public VentasController(IVentasServices ventasServices) 
        {
            this.ventasServices = ventasServices;
        }


        [HttpPost]
        public IActionResult CreateSales(VentasRQ model)
        {
            ventasServices.HacerVentas(model);
            return Ok();
        }
        [HttpGet]
        public IActionResult Get() 
        {
            try
            {
                var listar = ventasServices.Listar();
                return Ok(listar);
            }
            catch (Exception)
            {

                return BadRequest("Error al intentar listar la venta");
            }

        }
        [HttpGet("GetId")]
        public IActionResult GetId(int id) 
        {
            try
            {
                var listar = ventasServices.ListarID(id);
                if (listar.Count > 0)
                {
                    return Ok(listar);
                }
                return BadRequest("EstA Venta no existe");

            }
            catch (Exception)
            {

                return BadRequest("Error al intentar listar la venta");
            }
           

        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                ventasServices.Delete(id);
                return Ok("Venta eliminada");
            }
            catch (Exception)
            {

                return Ok("Ha sucedido un error al eliminar esta tabla, verifique que haya eliminado su relacion");
            }
           
        }
        [HttpPut]
        public IActionResult Editar(int id, VentasViewModel model)
        {
            try
            {
                var ventasEditadas = ventasServices.Editar(id, model);
                return Ok(ventasEditadas);
            }
            catch (Exception )
            {

                return Ok("Ha Sucedido un problema al editar la ventas");
            }
           
        }

    }
}

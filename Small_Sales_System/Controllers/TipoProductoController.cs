using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Small_Sales_System.Models;
using Small_Sales_System.Models.ViewModel;
using Small_Sales_System.Servicios.Interfaces;

namespace Small_Sales_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TipoProductoController : ControllerBase
    {
        private readonly ITipoProductoServices tipoProductoServices;

        public TipoProductoController(ITipoProductoServices tipoProductoServices)
        {
            this.tipoProductoServices = tipoProductoServices;
        }

        [HttpPost]
        public IActionResult Create(TipoProductoViewModel model)
        {
            try
            {
                tipoProductoServices.Create(model);
                return Ok();
            }
            catch
            {
                return BadRequest("Ha sucedido un error al agregar la categoria");
            }
        }

        [HttpGet("GetId")]
        public IActionResult GetId(int id)
        {
            try
            {
                var listar = tipoProductoServices.ListarID(id);
                if (listar.Count > 0)
                {
                    return Ok(listar);
                }
                return BadRequest("Esta categoria no existe");
            }
            catch (Exception)
            {

                return BadRequest("Ha Sucedido un error al listar la categoria");
            }
        }

        [HttpGet]
        public IActionResult GetId()
        {
            try
            {
                var ListadoTipo = tipoProductoServices.Listar();
                return Ok(ListadoTipo);
            }
            catch (Exception)
            {

                return BadRequest("Ha Sucedido un error al listar la categoria");
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id) 
        {
            try
            {
                tipoProductoServices.Eliminar(id);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest("Ha Ocurrido un error al Eliminar esta categoria") ;
            }
        }

        [HttpPut]
        public IActionResult Edit(int id, TipoProductoViewModel model)
        {
            try
            {
                tipoProductoServices.Editar(model,id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Ha Ocurrido un error al Editar esta categoria");
            }
        }
    }
}

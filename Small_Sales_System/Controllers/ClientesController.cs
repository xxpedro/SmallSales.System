using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Claims;
using System.Security.Policy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Small_Sales_System.Models;
using Small_Sales_System.Models.ViewModel;
using Small_Sales_System.Servicios.Interfaces;

namespace Small_Sales_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteServices clienteServices;

        public ClientesController(IClienteServices clienteServices)
        {
            this.clienteServices = clienteServices;
        }

        [HttpPost]
        public IActionResult Create(ClienteViewModel model)
        {
            try
            {
       
                clienteServices.Agregar(model);
                return Ok();
               
            }
            catch
            {
                return BadRequest("Error al crear el cliente");
            }
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var listar = clienteServices.lista();
                return Ok(listar);
            }
            catch
            {
                return BadRequest("Error al listar el cliente");
            }
        }
        [HttpGet("GetID")]
        public IActionResult GetID(int id) 
        {
            try
            {
                var listar = clienteServices.ListarID(id);
                if (listar.Count() > 0)
                {
                    return Ok(listar);
                }
                else
                    return Ok("No se encontro ese usuario");
            }
            catch
            {

                return BadRequest("Error al listar el cliente");
            }

        }
        [HttpPut]
        public IActionResult Edit(int id, ClienteViewModel model )
        {
            try
            {
                clienteServices.Editar(id,model);
                return Ok();
            }
            catch
            {

                return BadRequest("Error al Editar el cliente");
            }
        }
        [HttpDelete]
        public IActionResult Delete(int id) 
        {
            try
            {
                clienteServices.Eliminar(id);
                return Ok();
            }

            catch 
            {
                return Ok("Ha Sucedido un error al eliminar este cliente, verifique que no este relacionado a otra tabla");
            }
        }
    }
}

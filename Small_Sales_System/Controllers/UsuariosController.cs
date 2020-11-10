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
    public class UsuariosController : ControllerBase
    {

        private IUsuariosServices usuariosServices;
        public UsuariosController(IUsuariosServices usuariosServices)
        {
            this.usuariosServices = usuariosServices;

        }

        [HttpPost("Login")]
        public IActionResult Autentificar([FromBody] AutenticarRQ model)
        {
            try
            {
                var usuarios = usuariosServices.Logueo(model);

                if (usuarios == null)
                {
                    return BadRequest("Usuario o Clave incorrectas");
                }

                return Ok(usuarios);

            }
            catch (Exception)
            {

                return BadRequest("Ha pasado algo al loguearse");
            }
        }
        [HttpPost("Create")]
        public IActionResult Create([FromBody] UsuariosViewModel model)
        {
            try
            {
              usuariosServices.Create(model);
              return Ok();
            }
            catch (Exception)
            {

                return BadRequest("Error al crear el usuario");
            }
          
        }
        [Authorize]
        [HttpGet("Get")]
        public IActionResult Get() 
        {
            try
            {
                var ListaUsuarios = usuariosServices.Listar();
                return Ok(ListaUsuarios);
            }
            catch 
            {

                return BadRequest("Error al listar El Usuario");
            }
          
        }
        [Authorize]
        [HttpGet("GetID")]
        public IActionResult GetID(int id) 
        {
            try
            {
                var listar = usuariosServices.ListarID(id);
                if (listar.Count > 0)
                {
                    return Ok(listar);
                }
                return BadRequest("Esta categoria no existe");

            }
            catch
            {

                return BadRequest("Error A Eliminar el usuario ");
            }
           
        }
        [Authorize]
        [HttpPut("Edit")]
        public IActionResult Edit(int id, UsuariosViewModel usuarios) 
        {
            try
            {
                usuariosServices.Editar(id, usuarios);
                return Ok("Creado Con exito");

            }
            catch
            {

                return BadRequest("Error al listar El Usuario");
            }
           
        }
        [Authorize]
        [HttpDelete("Delete")]
        public IActionResult Delete(int id) 
        {
            try
            {
                usuariosServices.Eliminar(id);
                return Ok("Usuario Eliminado");

            }
            catch (Exception)
            {
                return BadRequest("Error al eliminar este usuario");
            }

        }
    }
}

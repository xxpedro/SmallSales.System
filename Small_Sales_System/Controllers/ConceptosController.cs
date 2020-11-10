using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Small_Sales_System.Models.ViewModel;
using Small_Sales_System.Servicios.Interfaces;

namespace Small_Sales_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ConceptosController : ControllerBase
    {
        private readonly IConceptosServices conceptosServices;

        public ConceptosController(IConceptosServices conceptosServices) 
        {
            this.conceptosServices = conceptosServices;
        }

        [HttpGet]
        public IActionResult Get() 
        {
            try
            {
                var listar=conceptosServices.lista();
                return Ok(listar);
                
            }
            catch 
            {

                return Ok("Ha Ocurrido un error al visualizar los conceptps");
            }
        }
        [HttpGet("GetID")]
        public IActionResult GetID(int id)
        {
            try
            {
                var listar = conceptosServices.ListarID(id);
                if (listar.Count > 0)
                {
                    return Ok(listar);
                }
                return BadRequest("Esta compra no se ha realizado");
            }
            catch
            {

                return Ok("Ha Ocurrido un error al visualizar los conceptps");
            }
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                conceptosServices.Eliminar(id);
                return Ok();
            }
            catch
            {

                return Ok("Ha Ocurrido un error al visualizar los conceptps");
            }
        }
        [HttpPut]
        public IActionResult Edit(int id,ConceptosViewModel model) 
        {
            try
            {
                conceptosServices.Editar(id, model);
                return Ok();
            }
            catch 
            {

               return Ok("Ha Sucedido un error al Editar este concepto");
            }
        }
       
    }
}

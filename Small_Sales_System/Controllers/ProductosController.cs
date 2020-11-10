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
    [Authorize]
    [ApiController]
    public class ProductosController : ControllerBase
    {


        private readonly IProductosServices productosServices;

        public ProductosController(IProductosServices productosServices)
        {
            this.productosServices = productosServices;
        }


        [HttpPost]
        public IActionResult Create(ProductosViewModel model)
        {
            try
            {
                productosServices.Agregar(model);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Ha pasado un error al Registrar el producto");

            }
            
        }
        [HttpGet("GetId")]
        public IActionResult GetId(int id) 
        {
            try
            {
                var listar = productosServices.ListarID(id);
                if (listar.Count > 0)
                {
                    return Ok(listar);
                }
                return BadRequest("Este producto no se ha agregado");
            }
            catch (Exception)
            {

                return BadRequest(); ;
            }

        }
        [HttpGet]
        public IActionResult Get() 
        {
            try
            {
                var listar = productosServices.lista();
                return Ok(listar);
             
            }
            catch (Exception)
            {

                return BadRequest("A ocurrido un error al Listar el producto");
            }
        }
        [HttpDelete]
        public IActionResult Delete(int id) 
        {
            try
            {
                productosServices.Eliminar(id);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest("A Sucedido un error al Eliminar el Producto") ;
            }
        }
        [HttpPut]
        public IActionResult Edit(int id, ProductosViewModel model) 
        {
            try
            {
                productosServices.Editar(id, model);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest("Algo a ocurrido al editar este producto");
            }
        }

    }
}

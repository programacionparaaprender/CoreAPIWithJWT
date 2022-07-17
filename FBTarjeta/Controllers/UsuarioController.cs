using FBTarjeta.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBTarjeta.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _tarjetaCreditoService;
        public UsuarioController(UsuarioService noticiaService)
        {
            this._tarjetaCreditoService = noticiaService;
        }


        [HttpGet]
        [Route("porUsuarioID/{usuarioID}")]
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult porUsuarioID(int usuarioID)
        {
            Usuario resultado = new Usuario();
            try
            {
                resultado = _tarjetaCreditoService.porUsuarioID(usuarioID);
                if (resultado != null)
                {
                    return Ok(new { message = "El usuario se obtuvo de forma exitosa", data = resultado });
                }
                return BadRequest(new { message = "El usuario no existe" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message, data = resultado });
            }
        }

        // GET: api/<TarjetaController>
        [HttpGet]
        [ProducesResponseType(typeof(TarjetaCredito), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get()
        {
            List<TarjetaCredito> resultado = new List<TarjetaCredito>();
            try
            {
                resultado = _tarjetaCreditoService.ObtenerTarjetas();
                return Ok(new { message = "Las tarjetas se han obtenido de forma exitosa", data = resultado });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message, data = resultado });
            }
        }

        // GET api/<TarjetaController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get(int id)
        {
            Usuario resultado = new Usuario();
            try
            {
                resultado = _tarjetaCreditoService.porUsuarioID(id);
                if (resultado != null)
                {
                    return Ok(new { message = "El usuario se obtuvo de forma exitosa", data = resultado });
                }
                //return Ok("Prueba de que todo funciona");
                //return HttpResult(200, resultado);
                return BadRequest(new { message = "El usuario no existe" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message, data = resultado });
            }
        }

        // POST api/<TarjetaController>
        [HttpPost]
        [ProducesResponseType(typeof(TarjetaCredito), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] TarjetaCredito _tarjeta)
        {
            TarjetaCredito resultado = new TarjetaCredito();
            try
            {
                resultado = _tarjetaCreditoService.agregarTarjeta(_tarjeta);
                if (resultado.Id != 0)
                {
                    //Created
                    return Created("url", new { message = "La tarjeta fue creada de forma exitosa", data = resultado });
                }

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            return BadRequest(new { message = "No se registro", data = resultado });
        }

        // PUT api/<TarjetaController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(TarjetaCredito), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put(int id, [FromBody] TarjetaCredito _tarjeta)
        {
            try
            {
                if (id != _tarjeta.Id)
                {
                    return NotFound();
                }
                var resultado = _tarjetaCreditoService.editarTarjetaCredito(id, _tarjeta);

                if (resultado)
                    return Created("url", new { message = "La tarjeta fue actualizada de forma exitosa", data = _tarjeta });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return BadRequest(new { message = "No se actualizo", data = _tarjeta });
        }

        // DELETE api/<TarjetaController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Usuario), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            Usuario _tarjeta = new Usuario();
            try
            {
                _tarjeta = _tarjetaCreditoService.porUsuarioID(id);
                var resultado = _tarjetaCreditoService.eliminarTarjeta(id);
                if (resultado)
                {
                    return Created("url", new { message = "El usuario fue eliminado de forma satisfactoria", data = _tarjeta });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message, data = _tarjeta });
            }
            return BadRequest(new { message = "No se elimino", data = _tarjeta });
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Global.Ophelia.Excepciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Ophelia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        public UsuariosController()
        {

        }

        /// <summary>
        /// Obtener clientes registrados
        /// </summary>
        /// <returns></returns>
        [HttpGet("ObtenerClientes")]
        public IActionResult ObtenerClientes()
        {
            return Ok();
        }

        /// <summary>
        /// Obtener cliente por documento
        /// </summary>
        /// <returns></returns>
        [HttpGet("ObtenerClientesPorDocumento")]
        public IActionResult ObtenerClientesPorDocumento([FromQuery][Required] int? identificacion)
        {
            if(identificacion is null)
            {
                var excepcion = DiccionarioMensajes.Get().ParametroRequerido;
                excepcion.Mensaje = $"identificacion: {excepcion.Mensaje}";
                throw new CustomException(excepcion);
            }
            else
            {
                return Ok();
            }

        }
    }
}
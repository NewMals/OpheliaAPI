using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DTOs.Ophelia.Usuarios;
using Global.Ophelia.Excepciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicios.Ophelia;

namespace API.Ophelia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        readonly IServicioUsuarios servicioUsuarios;
        public UsuariosController(IServicioUsuarios _servicioUsuarios)
        {
            servicioUsuarios = _servicioUsuarios;
        }

        /// <summary>
        /// Obtener clientes registrados
        /// </summary>
        /// <returns></returns>
        [HttpGet("ObtenerClientes")]
        public IActionResult ObtenerClientes()
        {
            return Ok(servicioUsuarios.ObtenerClientes());
        }

        /// <summary>
        /// Obtener proveedores registrados
        /// </summary>
        /// <returns></returns>
        [HttpGet("ObtenerProveedores")]
        public IActionResult ObtenerProveedores()
        {
            return Ok(servicioUsuarios.ObtenerProveedores());
        }

        /// <summary>
        /// Obtener usuario por documento
        /// </summary>
        /// <returns></returns>
        [HttpGet("ObtenerUsuariosPorIdentificacion")]
        public IActionResult ObtenerUsuariosPorIdentificacion([FromQuery][Required] string identificacion)
        {
            if(string.IsNullOrEmpty(identificacion))
            {
                var excepcion = DiccionarioMensajes.Get().ParametroRequerido;
                excepcion.Mensaje = $"identificacion: {excepcion.Mensaje}";
                throw new CustomException(excepcion);
            }
            else
            {
                return Ok(servicioUsuarios.ObtenerUsuariosPorIdentificacion(identificacion));
            }

        }

        /// <summary>
        /// Obtener roles
        /// </summary>
        [HttpGet("ObtenerRoles")]
        public IActionResult ObtenerRoles()
        {
            return Ok(servicioUsuarios.ObtenerRoles());
        }

        /// <summary>
        /// Crear o modificar usuariio
        /// </summary>
        [HttpPost("CrearOModificarUsuario")]
        public IActionResult CrearOModificarUsuario([FromBody] DTOUsuario usuario)
        {
            if (ModelState.IsValid)
            {
                ;
                return Ok(servicioUsuarios.CrearOModificarUsuario(usuario));
            }
            else
            {
                throw new CustomException(Validaciones.ValidacionesDto(ModelState));
            }

        }
    }
}
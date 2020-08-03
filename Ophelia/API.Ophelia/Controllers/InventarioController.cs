using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicios.Ophelia;

namespace API.Ophelia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventarioController : ControllerBase
    {
        readonly IServicioProductos servicioProductos;
        public InventarioController(IServicioProductos _servicioProductos)
        {
            servicioProductos = _servicioProductos;
        }

        /// <summary>
        /// Obtener productos
        /// </summary>
        /// <returns></returns>
        [HttpGet("ObtenerProductos")]
        public IActionResult ObtenerProductos()
        {
            return Ok(servicioProductos.ObtenerProductos());
        }
    }
}
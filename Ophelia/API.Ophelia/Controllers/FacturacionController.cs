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
    public class FacturacionController : ControllerBase
    {
        readonly IServicioFacturacion servicioFacturacion;
        public FacturacionController(IServicioFacturacion _servicioFacturacion)
        {
            servicioFacturacion = _servicioFacturacion;
        }

        /// <summary>
        /// Obtener facturas de compra
        /// </summary>
        /// <returns></returns>
        [HttpGet("ObtenerFacturasCompra")]
        public IActionResult ObtenerFacturasCompra()
        {
            return Ok(servicioFacturacion.ObtenerCompras());
        }

        /// <summary>
        /// Obtener facturas de venta
        /// </summary>
        /// <returns></returns>
        [HttpGet("ObtenerFacturasVenta")]
        public IActionResult ObtenerFacturasVenta()
        {
            return Ok(servicioFacturacion.ObtenerVentas());
        }
    }
}
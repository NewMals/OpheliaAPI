using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO.Ophelia.Facturacion;
using Global.Ophelia.Excepciones;
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

        /// <summary>
        /// Crear factura de compra
        /// </summary>
        [HttpPost("CrearFacturaCompra")]
        public IActionResult CrearFacturaCompra([FromBody] DTOProductosCompra factura)
        {
            if (ModelState.IsValid)
            {             
                return Ok(servicioFacturacion.CrearFacturaCompra(factura));
            }
            else
            {
                throw new CustomException(Validaciones.ValidacionesDto(ModelState));
            }
        }

        /// <summary>
        /// Crear factura de venta
        /// </summary>
        [HttpPost("CrearFacturaVenta")]
        public IActionResult CrearFacturaVenta([FromBody] DTOProductosVenta factura)
        {
            if (ModelState.IsValid)
            {
                return Ok(servicioFacturacion.CrearFacturaVenta(factura));
            }
            else
            {
                throw new CustomException(Validaciones.ValidacionesDto(ModelState));
            }
        }
    }
}
using DTO.Ophelia.Facturacion;
using DTOs.Ophelia.General;
using DTOs.Ophelia.Usuarios;
using Global.Ophelia.Constantes;
using Global.Ophelia.Excepciones;
using Infraestructura.Ophelia.Repositorios;
using ServiciosAplicacion.Ophelia.Validaciones;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Servicios.Ophelia
{
    public interface IServicioFacturacion
    {
        List<DTOFactura> ObtenerVentas();
        List<DTOFactura> ObtenerCompras();
        DTOResultado CrearFacturaCompra(DTOProductosCompra factura);
        DTOResultado CrearFacturaVenta(DTOProductosVenta factura);
    }

    class ServicioFacturacion : IServicioFacturacion
    {
        readonly IRepositorioFacturacion repositorioFacturacion;
        readonly IServicioUsuarios servicioUsuarios;
        readonly IServicioProductos servicioProductos;
        readonly IValidacionFacturacion validacionFacturacion;

        public ServicioFacturacion(IRepositorioFacturacion _repositorioFacturacion,
            IServicioUsuarios _servicioUsuarios,
            IServicioProductos _servicioProductos,
            IValidacionFacturacion _validacionFacturacion)
        {
            repositorioFacturacion = _repositorioFacturacion;
            servicioUsuarios = _servicioUsuarios;
            servicioProductos = _servicioProductos;
            validacionFacturacion = _validacionFacturacion;
        }

        public List<DTOFactura> ObtenerVentas()
        {
            return repositorioFacturacion.ObtenerVentas().Select(s => new DTOFactura() {
                Id = s.Id,
                Producto = servicioProductos.ObtenerProductosPorCodigo(s.CodigoProducto),
                Usuario = servicioUsuarios.ObtenerUsuariosPorId(s.Cliente),
                Cantidad = s.Cantidad,
                Fecha = s.FechaVenta,
                ValorTotal = s.ValorTotal,
                ValorUnitario = s.ValorUnitario
            }).ToList();
        }

        public List<DTOFactura> ObtenerCompras()
        {
            return repositorioFacturacion.ObtenerCompras().Select(s => new DTOFactura()
            {
                Id = s.Id,
                Producto = servicioProductos.ObtenerProductosPorCodigo(s.CodigoProducto),
                Usuario = servicioUsuarios.ObtenerUsuariosPorId(s.Proveedor),
                Cantidad = s.Cantidad,
                Fecha = s.FechaCompra,
                ValorTotal = s.ValorTotal,
                ValorUnitario = s.ValorUnitario
            }).ToList();
        }

        public DTOResultado CrearFacturaCompra(DTOProductosCompra factura)
        {
            validacionFacturacion.ValidarFacturaCompra(factura);
            factura.FechaCompra = DateTime.Now;
            var idCompra = repositorioFacturacion.CrearCompra(factura);
            
            return new DTOResultado()
            {
                Codigo = 1,
                Mensaje = $"Factura {idCompra} creada correctamente."
            };
        }

        public DTOResultado CrearFacturaVenta(DTOProductosVenta factura)
        {
            validacionFacturacion.ValidarFacturaVenta(factura);
            factura.FechaVenta = DateTime.Now;
            var idVenta = repositorioFacturacion.CrearVenta(factura);

            return new DTOResultado()
            {
                Codigo = 1,
                Mensaje = $"Factura {idVenta} creada correctamente."
            };
        }
    }
}

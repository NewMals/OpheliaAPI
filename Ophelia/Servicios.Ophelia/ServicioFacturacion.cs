using DTO.Ophelia.Facturacion;
using DTOs.Ophelia.Usuarios;
using Global.Ophelia.Constantes;
using Global.Ophelia.Excepciones;
using Infraestructura.Ophelia.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Servicios.Ophelia
{
    public interface IServicioFacturacion
    {
        List<DTOFactura> ObtenerVentas();
        List<DTOFactura> ObtenerCompras();
    }

    class ServicioFacturacion : IServicioFacturacion
    {
        readonly IRepositorioFacturacion repositorioFacturacion;
        readonly IServicioUsuarios servicioUsuarios;
        readonly IServicioProductos servicioProductos;

        public ServicioFacturacion(IRepositorioFacturacion _repositorioFacturacion,
            IServicioUsuarios _servicioUsuarios,
            IServicioProductos _servicioProductos)
        {
            repositorioFacturacion = _repositorioFacturacion;
            servicioUsuarios = _servicioUsuarios;
            servicioProductos = _servicioProductos;
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
    }
}

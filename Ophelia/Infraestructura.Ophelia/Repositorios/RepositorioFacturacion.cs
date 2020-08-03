using DTO.Ophelia.Facturacion;
using DTOs.Ophelia.Usuarios;
using Infraestructura.Ophelia.Modelos.OPH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infraestructura.Ophelia.Repositorios
{
    public interface IRepositorioFacturacion
    {
        List<DTOProductosCompra> ObtenerCompras();
        List<DTOProductosVenta> ObtenerVentas();
    }
    class RepositorioFacturacion : IRepositorioFacturacion
    {
        readonly Contexto contexto;
        public RepositorioFacturacion(Contexto _contextoFacturacion)
        {
            contexto = _contextoFacturacion;
        }

        public List<DTOProductosCompra> ObtenerCompras()
        {
            return contexto.ProductosCompra.Select(s => DePersistenciaADTOCompra(s)).ToList();
            
        }

        public List<DTOProductosVenta> ObtenerVentas()
        {
            return contexto.ProductosVenta.Select(s => DePersistenciaADTOVenta(s)).ToList();
        }


        private DTOProductosCompra DePersistenciaADTOCompra(ProductosCompra compra)
        {
            return new DTOProductosCompra()
            {
                Id = compra.Id,
                CodigoProducto = compra.CodigoProducto,
                Proveedor = compra.Proveedor,
                Cantidad = compra.Cantidad,
                FechaCompra = compra.FechaCompra,
                ValorTotal = compra.ValorTotal,
                ValorUnitario = compra.ValorUnitario
            };
        }

        private DTOProductosVenta DePersistenciaADTOVenta(ProductosVenta compra)
        {
            return new DTOProductosVenta()
            {
                Id = compra.Id,
                CodigoProducto = compra.CodigoProducto,
                Cliente = compra.Cliente,
                Cantidad = compra.Cantidad,
                FechaVenta = compra.FechaVenta,
                ValorTotal = compra.ValorTotal,
                ValorUnitario = compra.ValorUnitario
            };
        }
    }
}

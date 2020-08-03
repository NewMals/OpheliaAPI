using DTO.Ophelia.Facturacion;
using DTOs.Ophelia.Productos;
using DTOs.Ophelia.Usuarios;
using Global.Ophelia.Constantes;
using Global.Ophelia.Excepciones;
using Infraestructura.Ophelia.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Servicios.Ophelia
{
    public interface IServicioProductos
    {
        List<DTOProducto> ObtenerProductos();
        DTOProducto ObtenerProductosPorCodigo(string codigoProducto);
    }

    class ServicioProductos : IServicioProductos
    {
        readonly IRepositorioProductos repositorioProductos;

        public ServicioProductos(IRepositorioProductos _repositorioProductos)
        {
            repositorioProductos = _repositorioProductos;
        }

        public List<DTOProducto> ObtenerProductos()
        {
            return repositorioProductos.ObtenerProductos().OrderBy(o => o.Id).ToList();
        }

        public DTOProducto ObtenerProductosPorCodigo(string codigoProducto)
        {
            return repositorioProductos.ObtenerProductosPorCodigo(codigoProducto);
        }
    }
}

using DTOs.Ophelia.Productos;
using DTOs.Ophelia.Usuarios;
using Infraestructura.Ophelia.Modelos.OPH;
using Infraestructura.Ophelia.Modelos.OPH_SYS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infraestructura.Ophelia.Repositorios
{
    public interface IRepositorioProductos
    {
        List<DTOProducto> ObtenerProductos();
        DTOProducto ObtenerProductosPorCodigo(string codigoProducto);
    }
    class RepositorioProductos : IRepositorioProductos
    {
        readonly Contexto contexto;
        public RepositorioProductos(Contexto _contexto)
        {
            contexto = _contexto;
        }

        public List<DTOProducto> ObtenerProductos()
        {
            return contexto.Productos.Select(s => DePersistenciaADTO(s)).ToList();
        }

        public DTOProducto ObtenerProductosPorCodigo(string codigoProducto)
        {
            var producto = contexto.Productos.Where(w => w.Codigo == codigoProducto).SingleOrDefault();
            return DePersistenciaADTO(producto);
        }

        private DTOProducto DePersistenciaADTO(Productos producto)
        {
            return new DTOProducto()
            {
                Id = producto.Id,
                Codigo = producto.Codigo,
                Descripcion = producto.Descripcion
            };
        }
    }
}

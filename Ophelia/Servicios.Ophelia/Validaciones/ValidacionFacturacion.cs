using DTO.Ophelia.Facturacion;
using Global.Ophelia.Excepciones;
using Infraestructura.Ophelia.Repositorios;
using Servicios.Ophelia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiciosAplicacion.Ophelia.Validaciones
{
    public interface IValidacionFacturacion
    {
        void ValidarFacturaCompra(DTOProductosCompra factura);
        void ValidarFacturaVenta(DTOProductosVenta factura);
    }
    public class ValidacionFacturacion: IValidacionFacturacion
    {
        readonly IRepositorioFacturacion repositorioFacturacion;
        readonly IRepositorioProductos repositorioProductos;
        readonly IRepositorioUsuarios repositorioUsuarios;

        public ValidacionFacturacion(IRepositorioFacturacion _repositorioFacturacion,
            IRepositorioProductos _repositorioProductos,
            IRepositorioUsuarios _repositorioUsuarios)
        {
            repositorioFacturacion = _repositorioFacturacion;
            repositorioProductos = _repositorioProductos;
            repositorioUsuarios = _repositorioUsuarios;
        }

        public void ValidarFacturaCompra(DTOProductosCompra factura)
        {
            if(repositorioProductos.ObtenerProductosPorCodigo(factura.CodigoProducto) is null)
            {
                var excepcion = DiccionarioMensajes.Get().PropiedadNoExiste;
                excepcion.Mensaje = excepcion.Mensaje.Replace("{0}",$"El producto con codigo {factura.CodigoProducto}").Replace("{1}", "o");
                throw new CustomException(excepcion);
            }

            if(repositorioUsuarios.ObtenerUsuariosPorId(factura.Proveedor) is null)
            {
                var excepcion = DiccionarioMensajes.Get().PropiedadNoExiste;
                excepcion.Mensaje = excepcion.Mensaje.Replace("{0}", $"El proveedor con id {factura.Proveedor}").Replace("{1}", "o");
                throw new CustomException(excepcion);
            }
        }

        public void ValidarFacturaVenta(DTOProductosVenta factura)
        {
            if (repositorioProductos.ObtenerProductosPorCodigo(factura.CodigoProducto) is null)
            {
                var excepcion = DiccionarioMensajes.Get().PropiedadNoExiste;
                excepcion.Mensaje = excepcion.Mensaje.Replace("{0}", $"El producto con codigo {factura.CodigoProducto}").Replace("{1}", "o");
                throw new CustomException(excepcion);
            }

            if (repositorioUsuarios.ObtenerUsuariosPorId(factura.Cliente) is null)
            {
                var excepcion = DiccionarioMensajes.Get().PropiedadNoExiste;
                excepcion.Mensaje = excepcion.Mensaje.Replace("{0}", $"El cliente con id {factura.Cliente}").Replace("{1}", "o");
                throw new CustomException(excepcion);
            }
        }
    }
}

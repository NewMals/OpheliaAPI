using DTOs.Ophelia.Usuarios;
using Infraestructura.Ophelia.Modelos.OPH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infraestructura.Ophelia.Repositorios
{
    public interface IRepositorioUsuarios
    {
        List<DTOUsuario> ObtenerUsuarios();
        DTOUsuario ObtenerUsuarioPorIdentificacion(string identificacion);
    }
    class RepositorioUsuarios : IRepositorioUsuarios
    {
        readonly Contexto contextoFacturacion;
        public RepositorioUsuarios(Contexto _contextoFacturacion)
        {
            contextoFacturacion = _contextoFacturacion;
        }

        public DTOUsuario ObtenerUsuarioPorIdentificacion(string identificacion)
        {
            var usuario = contextoFacturacion.Usuarios.Where(w => w.Identificacion == identificacion).SingleOrDefault();
            return DePersistenciaADTO(usuario);

        }

        public List<DTOUsuario> ObtenerUsuarios()
        {
            return contextoFacturacion.Usuarios.Select(s => DePersistenciaADTO(s)).ToList();
        }

        private DTOUsuario DePersistenciaADTO(Usuarios usuario)
        {
            return new DTOUsuario()
            {
                Id = usuario.Id,
                Identificacion = usuario.Identificacion,
                Nombres = usuario.Nombres,
                Apellidos = usuario.Apellidos,
                FechaNacimiento = usuario.FechaNacimiento,
                FechaRegistro = usuario.FechaRegistro,
                Rol = usuario.Rol,
                Telefono = usuario.Telefono
            };
        }
    }
}

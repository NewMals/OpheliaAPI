using DTOs.Ophelia.Usuarios;
using Global.Ophelia.Constantes;
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
        DTOUsuario ObtenerUsuariosPorId(int id);
        List<DTOUsuariosRoles> ObtenerUsuariosRoles();
        void CrearUsuario(DTOUsuario usuario);
        void Actualizar(DTOUsuario usuario);
    }
    class RepositorioUsuarios : IRepositorioUsuarios
    {
        readonly Contexto contexto;
        public RepositorioUsuarios(Contexto _contextoFacturacion)
        {
            contexto = _contextoFacturacion;
        }

        public DTOUsuario ObtenerUsuarioPorIdentificacion(string identificacion)
        {
            var usuario = contexto.Usuarios.Where(w => w.Rol != (int)UsuariosRoles.Sistema && w.Identificacion == identificacion).SingleOrDefault();
            return usuario is null ? null : DePersistenciaADTO(usuario);
        }

        public DTOUsuario ObtenerUsuariosPorId(int id)
        {
            var usuario = contexto.Usuarios.Where(w => w.Rol != (int)UsuariosRoles.Sistema && w.Id == id).SingleOrDefault();
            return usuario is null ? null : DePersistenciaADTO(usuario);
        }

        public List<DTOUsuario> ObtenerUsuarios()
        {
            return contexto.Usuarios.Select(s => DePersistenciaADTO(s)).ToList();
        }

        public List<DTOUsuariosRoles> ObtenerUsuariosRoles()
        {
            return contexto.UsuariosRoles.Select(s => new DTOUsuariosRoles()
            {
                Id = s.Id,
                Descripcion = s.Descripcion,
                Interno = s.Interno
            }).ToList();
        }

        public void CrearUsuario(DTOUsuario usuario)
        {
            contexto.Usuarios.Add(DeDTOAPersistencia(usuario));
            contexto.SaveChanges();
        }

        public void Actualizar(DTOUsuario usuario)
        {
            var usuarioActual = contexto.Usuarios.FirstOrDefault(f => f.Id == usuario.Id);
            if (!(usuarioActual is null))
            {
                usuarioActual.Telefono = usuario.Telefono;
                contexto.Usuarios.Update(usuarioActual);
            }
            contexto.SaveChanges();
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

        private Usuarios DeDTOAPersistencia(DTOUsuario usuario)
        {
            return new Usuarios()
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

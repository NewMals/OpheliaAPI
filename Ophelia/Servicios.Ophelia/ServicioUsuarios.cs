using DTOs.Ophelia.General;
using DTOs.Ophelia.Usuarios;
using Global.Ophelia.Constantes;
using Global.Ophelia.Excepciones;
using Infraestructura.Ophelia.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Servicios.Ophelia
{
    public interface IServicioUsuarios
    {
        List<DTOUsuario> ObtenerClientes();
        DTOUsuario ObtenerUsuariosPorIdentificacion(string identificacion);
        DTOUsuario ObtenerUsuariosPorId(int id);
        List<DTOUsuario> ObtenerProveedores();
        List<DTOUsuariosRoles> ObtenerRoles();
        DTOResultado CrearOModificarUsuario(DTOUsuario usuario);
    }

    class ServicioUsuarios : IServicioUsuarios
    {
        readonly IRepositorioUsuarios repositorioUsuarios;

        public ServicioUsuarios(IRepositorioUsuarios _repositorioUsuarios)
        {
            repositorioUsuarios = _repositorioUsuarios;
        }

        public List<DTOUsuario> ObtenerClientes()
        {
            return repositorioUsuarios.ObtenerUsuarios().Where(w => w.Rol == (int)UsuariosRoles.Cliente).ToList();
        }


        public DTOUsuario ObtenerUsuariosPorIdentificacion(string identificacion)
        {
            return repositorioUsuarios.ObtenerUsuarioPorIdentificacion(identificacion);
        }

        public DTOUsuario ObtenerUsuariosPorId(int id)
        {
            return repositorioUsuarios.ObtenerUsuariosPorId(id);
        }

        public List<DTOUsuario> ObtenerProveedores()
        {
            return repositorioUsuarios.ObtenerUsuarios().Where(w => w.Rol == (int)UsuariosRoles.Proveedor).ToList();
        }

        public List<DTOUsuariosRoles> ObtenerRoles()
        {
            return repositorioUsuarios.ObtenerUsuariosRoles().Where(w => !w.Interno).ToList();
        }

        public DTOResultado CrearOModificarUsuario(DTOUsuario usuario)
        {
            var queryUsuario = ObtenerUsuariosPorIdentificacion(usuario.Identificacion);
            if (queryUsuario is null)
            {
                usuario.FechaRegistro = DateTime.Now;
                repositorioUsuarios.CrearUsuario(usuario);
            }
            else
            {
                if (queryUsuario.Identificacion != usuario.Identificacion)
                {
                    var excepcion = DiccionarioMensajes.Get().ExisteUsuario;
                    excepcion.Mensaje = excepcion.Mensaje.Replace("{0}", usuario.Identificacion);
                    throw new CustomException(excepcion);
                }          
                repositorioUsuarios.Actualizar(usuario);
            }
            return new DTOResultado()
            {
                Codigo = 1,
                Mensaje = $"Usuario {usuario.Nombres} {usuario.Apellidos} guardado correctamente."
            };
        }
    }
}

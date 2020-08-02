using DTOs.Ophelia.Usuarios;
using Global.Ophelia.Constantes;
using Infraestructura.Ophelia.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Servicios.Ophelia
{
    public interface IServicioUsuarios
    {
        List<DTOUsuario> ObtenerClientes();
        DTOUsuario ObtenerClientePorIdentificacion(string identificacion);
        List<DTOUsuario> ObtenerProveedores();
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


        public DTOUsuario ObtenerClientePorIdentificacion(string identificacion)
        {
            return repositorioUsuarios.ObtenerUsuarios().Where(w => w.Rol == (int)UsuariosRoles.Cliente && w.Identificacion == identificacion).FirstOrDefault();
        }

        public List<DTOUsuario> ObtenerProveedores()
        {
            return repositorioUsuarios.ObtenerUsuarios().Where(w => w.Rol == (int)UsuariosRoles.Proveedor).ToList();
        }
    }
}

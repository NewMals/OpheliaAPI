using Global.Ophelia.Sesion;
using Infraestructura.Ophelia.Modelos.OPH;
using Infraestructura.Ophelia.Modelos.OPH_AUDIT;
using Infraestructura.Ophelia.Modelos.OPH_SYS;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System;

namespace Infraestructura
{
    public class Contexto: DbContext
    {

        public Contexto(IConstruirSesion construirSesion)
            : base(construirSesion.ObtenerContextOptions(new DbContextOptionsBuilder<Contexto>()))
        {
            if (!(Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists())
            {
                throw new Exception("No se ha creado la base de datos");
            }
        }


        public DbSet<ProductosCompra> ProductosCompra { get; set; }
        public DbSet<ProductosInventario> ProductosInventario { get; set; }
        public DbSet<ProductosVenta> ProductosVenta { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Inventario> Inventario { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<UsuariosRoles> UsuariosRoles { get; set; }
    }
}

using Infraestructura.Ophelia.Modelos.OPH;
using Infraestructura.Ophelia.Modelos.OPH_AUDIT;
using Infraestructura.Ophelia.Modelos.OPH_SYS;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infraestructura
{
    public class ContextoFacturacion: DbContext
    {
        public ContextoFacturacion(DbContextOptions<ContextoFacturacion> options)
            : base(options)
        {

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

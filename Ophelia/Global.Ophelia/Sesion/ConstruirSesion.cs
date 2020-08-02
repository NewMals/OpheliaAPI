using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Global.Ophelia.Sesion
{
    public interface IConstruirSesion
    {
        DbContextOptions ObtenerContextOptions(DbContextOptionsBuilder builder);
        string ObtenerCadenaConexion();

    }
    public class ConstruirSesion : IConstruirSesion
    {
        readonly IConfiguration configuration;
        public ConstruirSesion(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public DbContextOptions ObtenerContextOptions(DbContextOptionsBuilder builder)
        {
            var cadenaConexion = ObtenerCadenaConexion();
            builder.UseSqlServer(
                cadenaConexion
            );
            return builder.Options;
        }

        public string ObtenerCadenaConexion()
        {
            return configuration.GetConnectionString("DevelopConnection");
        }
    }
}

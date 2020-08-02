using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.Ophelia.Usuarios
{
    public class DTOUsuario
    {
        public int Id { get; set; }

        public string Identificacion { get; set; }

        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public DateTime FechaRegistro { get; set; }

        public int Telefono { get; set; }

        public int Rol { get; set; }
    }
}

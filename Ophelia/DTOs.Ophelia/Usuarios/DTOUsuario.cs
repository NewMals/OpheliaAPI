using Global.Ophelia.Excepciones;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTOs.Ophelia.Usuarios
{
    public class DTOUsuario
    {
        public int Id { get; set; }
        [Required(ErrorMessage = nameof(DiccionarioMensajes.PropiedadRequerida))]
        public string Identificacion { get; set; }
        [Required(ErrorMessage = nameof(DiccionarioMensajes.PropiedadRequerida))]
        public string Nombres { get; set; }
        [Required(ErrorMessage = nameof(DiccionarioMensajes.PropiedadRequerida))]
        public string Apellidos { get; set; }
        [Required(ErrorMessage = nameof(DiccionarioMensajes.PropiedadRequerida))]
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaRegistro { get; set; }
        [Required(ErrorMessage = nameof(DiccionarioMensajes.PropiedadRequerida))]
        public int Telefono { get; set; }
        public int Rol { get; set; }
    }
}

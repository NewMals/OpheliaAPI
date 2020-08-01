using Global.Ophelia.Constantes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infraestructura.Ophelia.Modelos.OPH
{
    [Table("Usuarios", Schema = ConstantesBaseDatos.Schema)]
    public class Usuarios
    {
        [Key]
        [Column("USUid")]
        public int Id { get; set; }

        [Column("USUidentificacion")]
        [StringLength(50)]
        public string Identificacion { get; set; }

        [Column("USUnombres")]
        [StringLength(100)]
        public string Nombres { get; set; }

        [Column("USUapellidos")]
        [StringLength(100)]
        public string Apellidos { get; set; }

        [Column("USUfechaNacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Column("USUfechaRegistro")]
        public DateTime FechaRegistro{ get; set; }

        [Column("USUtelefono")]
        public int Telefono { get; set; }

        [Column("USUrol")]
        public int Rol { get; set; }

    }
}

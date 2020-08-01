using Global.Ophelia.Constantes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infraestructura.Ophelia.Modelos.OPH_SYS
{
    [Table("UsuariosRoles", Schema = ConstantesBaseDatos.SchemaConfiguration)]
    public class UsuariosRoles
    {
        [Key]
        [Column("UROid")]
        public int Id { get; set; }

        [Column("UROdescripcion")]
        [StringLength(100)]
        public string Descripcion { get; set; }
        
        [Column("UROinterno")]
        public bool Interno { get; set; }

    }
}

using Global.Ophelia.Constantes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infraestructura.Ophelia.Modelos.OPH_SYS
{
    [Table("Productos", Schema = ConstantesBaseDatos.SchemaConfiguration)]
    public class Productos
    {

        [Column("PROid")]
        public int Id { get; set; }

        [Key]
        [Column("PROcodigo")]
        [StringLength(50)]
        public string Codigo { get; set; }

        [Column("PROdescripcion")]
        [StringLength(1000)]
        public string Descripcion { get; set; }



    }
}

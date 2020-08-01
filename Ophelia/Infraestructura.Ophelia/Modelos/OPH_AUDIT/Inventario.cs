using Global.Ophelia.Constantes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infraestructura.Ophelia.Modelos.OPH_AUDIT
{
    [Table("Inventario", Schema = ConstantesBaseDatos.SchemaAudit)]
    public class Inventario
    {
        [Key]
        [Column("INVid")]
        public int Id { get; set; }

        [Column("INVcodigoProducto")]
        [StringLength(50)]
        public string CodigoProducto { get; set; }
        
        [Column("INVfecha")]
        public DateTime Fecha { get; set; }

        [Column("INVcompra")]        
        public int IdCompra { get; set; }

        [Column("INVventa")]
        public int IdVenta { get; set; }

        [Column("INVcantidad")]
        public int Cantidad { get; set; }

    }
}

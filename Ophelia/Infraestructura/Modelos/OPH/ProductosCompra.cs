using Global.Ophelia.Constantes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infraestructura.Ophelia.Modelos.OPH
{
    [Table("ProductosCompra", Schema = ConstantesBaseDatos.Schema)]
    public class ProductosCompra
    {
        [Key]
        [Column("PCOid")]
        public int Id { get; set; }

        [Column("PCOcodigoProducto")]
        [StringLength(50)]
        public string CodigoProducto { get; set; }

        [Column("PCOprovedor")]
        public int Proveedor { get; set; }

        [Column("PCOcantidad")]
        public int Cantidad { get; set; }

        [Column("PCOfechaCompra")]
        public DateTime FechaCompra { get; set; }

        [Column("PCOvalorUnitario")]
        public decimal ValorUnitario { get; set; }

        [Column("PCOvalorTotal")]
        public decimal ValorTotal { get; set; }
    }
}

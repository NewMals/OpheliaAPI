using Global.Ophelia.Constantes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infraestructura.Ophelia.Modelos.OPH
{
    [Table("ProductosVenta", Schema = ConstantesBaseDatos.Schema)]
    public class ProductosVenta
    {
        [Key]
        [Column("PVEid")]
        public int Id { get; set; }

        [Column("PVEcodigoProducto")]
        [StringLength(50)]
        public string CodigoProducto { get; set; }

        [Column("PVEcliente")]
        public int Cliente { get; set; }

        [Column("PVEcantidad")]
        public int Cantidad { get; set; }

        [Column("PVEfechaVenta")]
        public DateTime FechaVenta { get; set; }

        [Column("PVEvalorUnitario")]
        public decimal ValorUnitario { get; set; }

        [Column("PVEvalorTotal")]
        public decimal ValorTotal { get; set; }
    }
}

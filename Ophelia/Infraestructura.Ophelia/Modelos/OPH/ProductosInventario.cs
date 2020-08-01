using Global.Ophelia.Constantes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infraestructura.Ophelia.Modelos.OPH
{
    [Table("ProductosInventario", Schema = ConstantesBaseDatos.Schema)]
    public class ProductosInventario
    {     
        [Column("PINid")]
        public int Id { get; set; }

        [Key]
        [Column("PINcodigoProducto")]
        [StringLength(50)]
        public string CodigoProducto { get; set; }
        
        [Column("PINcantidad")]
        public int Cantidad { get; set; }

        [Column("PINvalor")]
        public decimal Valor { get; set; }

    }
}

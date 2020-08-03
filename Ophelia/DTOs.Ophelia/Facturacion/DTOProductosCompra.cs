using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO.Ophelia.Facturacion
{

    public class DTOProductosCompra
    {
        public int Id { get; set; }
        public string CodigoProducto { get; set; }
        public int Proveedor { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaCompra { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal { get; set; }
    }
}

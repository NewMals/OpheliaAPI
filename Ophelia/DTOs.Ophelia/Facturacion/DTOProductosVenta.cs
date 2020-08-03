
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO.Ophelia.Facturacion
{
  public class DTOProductosVenta
    {
        public int Id { get; set; }
        public string CodigoProducto { get; set; }
        public int Cliente { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaVenta { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal { get; set; }
    }
}

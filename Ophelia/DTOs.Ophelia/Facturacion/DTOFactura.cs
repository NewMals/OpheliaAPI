using DTOs.Ophelia.Productos;
using DTOs.Ophelia.Usuarios;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO.Ophelia.Facturacion
{

    public class DTOFactura
    {
        public int Id { get; set; }
        public DTOProducto Producto { get; set; }
        public DTOUsuario Usuario { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal { get; set; }
    }
}

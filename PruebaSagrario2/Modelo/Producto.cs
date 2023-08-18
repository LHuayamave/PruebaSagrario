using System;
using System.Collections.Generic;

namespace PruebaSagrario2.Modelo
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioUnitario { get; set; }
        public string EstadoProducto { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public DateTime? FechaEliminacion { get; set; }
        public List<FacturaDetalle> FacturaDetalle { get; set; }
    }
}

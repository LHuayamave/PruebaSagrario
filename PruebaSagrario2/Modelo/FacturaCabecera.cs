using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaSagrario2.Modelo
{
    public class FacturaCabecera
    {
        public int IdFacturaCabecera { get; set; }
        public DateTime? FechaFacturaCreacion { get; set; }
        public string NumeroFactura { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public string NombreCliente { get; set; }
        public string NombreEmpresa { get; set; }
        public string DireccionEmpresa { get; set; }
        public string TelefonoEmpresa { get; set; }
        public decimal? Subtotal { get; set; }
        public decimal? Iva { get; set; }
        public decimal? TotalFactura { get; set; }
        public string EstadoFacturaCabecera { get; set; }
        public int IdPersona { get; set; }
        public List<FacturaDetalle> FacturaDetalle { get; set; }
    }
    public class FacturaDetalle
    {
        public int IdFacturaDetalle { get; set; }
        public int IdFacturaCabecera { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public double PrecioUnitario { get; set; }
        public double SubtotalProducto { get; set; }
    }
}

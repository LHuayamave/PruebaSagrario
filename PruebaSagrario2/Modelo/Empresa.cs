using System;
using System.Collections.Generic;

namespace PruebaSagrario2.Modelo
{
    internal class Empresa
    {
        public int IdEmpresa { get; set; }
        public string NombreEmpresa { get; set; }
        public string DireccionEmpresa { get; set; }
        public string TelefonoEmpresa { get; set; }
        public string EstadoEmpresa { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
    }
}

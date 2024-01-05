using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ReporteAspirantes
    {
        public int AspiranteID { get; set; }
        public string NombreAspirante { get; set; }
        public string ApellidoAspirante { get; set; }
        public int PruebaSeleccionID { get; set; }
        public string NombrePrueba { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinalizacion { get; set; }
        public string TipoPrueba { get; set; }
        public string LenguajeProgramacion { get; set; }
        public int CantidadPreguntas { get; set; }
        public string Nivel { get; set; }
        public string EstadoPrueba { get; set; }
    }
}

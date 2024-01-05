using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class PruebaSeleccionDTO
    {
        public int Id { get; set; }
        public string NombreDescripcion { get; set; }
        public int AspiranteId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinalizacion { get; set; }
        public string TipoPrueba { get; set; }
        public string LenguajeProgramacion { get; set; }
        public int CantidadPreguntas { get; set; }
        public string Nivel { get; set; }
        public string EstadoPrueba { get; set; }
    }
}

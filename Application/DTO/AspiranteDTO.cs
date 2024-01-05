using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class AspiranteDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DatosContacto { get; set; }
        public string EstadoPrueba { get; set; }
        public decimal Calificacion { get; set; }
    }
}

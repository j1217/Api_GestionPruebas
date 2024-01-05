using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Pregunta
    {
        public int Id { get; set; }
        public string TextoPregunta { get; set; }
        public string OpcionesRespuesta { get; set; }
        public string RespuestaCorrecta { get; set; }
        public string Usuario { get; set; }
        public DateTime FechaActualizacion { get; set; }
    }
}

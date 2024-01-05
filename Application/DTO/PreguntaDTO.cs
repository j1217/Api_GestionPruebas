using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class PreguntaDTO
    {
        public int Id { get; set; }
        public string TextoPregunta { get; set; }
        public string OpcionesRespuesta { get; set; }
        public string RespuestaCorrecta { get; set; }
    }
}

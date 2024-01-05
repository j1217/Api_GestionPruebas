using Application.DTO;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extensions
{
    public static class PreguntaExtensions
    {
        public static PreguntaDTO ToDTO(this Pregunta pregunta)
        {
            return new PreguntaDTO
            {
                Id = pregunta.Id,
                TextoPregunta = pregunta.TextoPregunta,
                OpcionesRespuesta = pregunta.OpcionesRespuesta,
                RespuestaCorrecta = pregunta.RespuestaCorrecta
            };
        }
    }
}

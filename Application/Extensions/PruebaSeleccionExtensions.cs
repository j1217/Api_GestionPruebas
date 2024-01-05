using Application.DTO;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extensions
{
    public static class PruebaSeleccionExtensions
    {
        public static PruebaSeleccionDTO ToDTO(this PruebaSeleccion pruebaSeleccion)
        {
            return new PruebaSeleccionDTO
            {
                Id = pruebaSeleccion.Id,
                NombreDescripcion = pruebaSeleccion.NombreDescripcion,
                AspiranteId = pruebaSeleccion.AspiranteId,
                FechaInicio = pruebaSeleccion.FechaInicio,
                FechaFinalizacion = pruebaSeleccion.FechaFinalizacion,
                TipoPrueba = pruebaSeleccion.TipoPrueba,
                LenguajeProgramacion = pruebaSeleccion.LenguajeProgramacion,
                CantidadPreguntas = pruebaSeleccion.CantidadPreguntas,
                Nivel = pruebaSeleccion.Nivel,
                EstadoPrueba = pruebaSeleccion.EstadoPrueba
            };
        }
    }
}

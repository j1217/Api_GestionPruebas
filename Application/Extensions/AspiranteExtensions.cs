using Application.DTO;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extensions
{
    public static class AspiranteExtensions
    {
        public static AspiranteDTO ToDTO(this Aspirante aspirante)
        {
            return new AspiranteDTO
            {
                Id = aspirante.Id,
                Nombre = aspirante.Nombre,
                Apellido = aspirante.Apellido,
                DatosContacto = aspirante.DatosContacto,
                EstadoPrueba = aspirante.EstadoPrueba,
                Calificacion = aspirante.Calificacion
            };
        }
    }
}

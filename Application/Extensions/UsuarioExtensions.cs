using Application.DTO;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extensions
{
    public static class UsuarioExtensions
    {
        public static UsuarioDTO ToDTO(this Usuario usuario)
        {
            return new UsuarioDTO
            {
                Id = usuario.Id,
                NombreUsuario = usuario.NombreUsuario,
                ContraseñaHash = usuario.ContraseñaHash,
                Rol = usuario.Rol
            };
        }
    }
}

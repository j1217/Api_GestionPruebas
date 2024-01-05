using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetUsuarioByIdAsync(int id);
        Task<IEnumerable<Usuario>> GetAllUsuariosAsync();
        Task AddUsuario(Usuario usuario);
        Task UpdateUsuario(Usuario usuario);
        Task RemoveUsuario(Usuario usuario);
    }
}

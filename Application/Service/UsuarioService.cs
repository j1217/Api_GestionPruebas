using Domain.Models;
using Domain.Repositories;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Usuario> GetUsuarioByIdAsync(int id)
        {
            return await _usuarioRepository.GetUsuarioByIdAsync(id);
        }

        public async Task<IEnumerable<Usuario>> GetAllUsuariosAsync()
        {
            return await _usuarioRepository.GetAllUsuariosAsync();
        }

        public async Task AddUsuario(Usuario usuario)
        {
            _usuarioRepository.AddUsuario(usuario);
        }

        public async Task UpdateUsuario(Usuario usuario)
        {
            _usuarioRepository.UpdateUsuario(usuario);
        }

        public async Task RemoveUsuario(Usuario usuario)
        {
            _usuarioRepository.RemoveUsuario(usuario);
        }
    }
}

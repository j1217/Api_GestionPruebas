using Domain.Models;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _dbContext;

        public UsuarioRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Usuario> GetUsuarioByIdAsync(int id)
        {
            return await _dbContext.Usuarios.FindAsync(id);
        }

        public async Task<IEnumerable<Usuario>> GetAllUsuariosAsync()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }

        public async Task AddUsuario(Usuario usuario)
        {
            _dbContext.Usuarios.Add(usuario);
        }

        public async Task UpdateUsuario(Usuario usuario)
        {
            _dbContext.Entry(usuario).State = EntityState.Modified;
        }

        public async Task RemoveUsuario(Usuario usuario)
        {
            _dbContext.Usuarios.Remove(usuario);
        }
    }
}

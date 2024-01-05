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
    public class PreguntaRepository : IPreguntaRepository
    {
        private readonly AppDbContext _dbContext;

        public PreguntaRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Pregunta> GetPreguntaByIdAsync(int id)
        {
            return await _dbContext.Preguntas.FindAsync(id);
        }

        public async Task<IEnumerable<Pregunta>> GetAllPreguntasAsync()
        {
            return await _dbContext.Preguntas.ToListAsync();
        }

        public async Task AddPregunta(Pregunta pregunta)
        {
            _dbContext.Preguntas.Add(pregunta);
        }

        public async Task UpdatePregunta(Pregunta pregunta)
        {
            _dbContext.Entry(pregunta).State = EntityState.Modified;
        }

        public async Task RemovePregunta(Pregunta pregunta)
        {
            _dbContext.Preguntas.Remove(pregunta);
        }
    }
}

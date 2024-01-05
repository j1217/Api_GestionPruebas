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
    public class PreguntaService : IPreguntaService
    {
        private readonly IPreguntaRepository _preguntaRepository;

        public PreguntaService(IPreguntaRepository preguntaRepository)
        {
            _preguntaRepository = preguntaRepository;
        }

        public async Task<Pregunta> GetPreguntaByIdAsync(int id)
        {
            return await _preguntaRepository.GetPreguntaByIdAsync(id);
        }

        public async Task<IEnumerable<Pregunta>> GetAllPreguntasAsync()
        {
            return await _preguntaRepository.GetAllPreguntasAsync();
        }

        public async Task AddPregunta(Pregunta pregunta)
        {
            _preguntaRepository.AddPregunta(pregunta);
        }

        public async Task UpdatePregunta(Pregunta pregunta)
        {
            _preguntaRepository.UpdatePregunta(pregunta);
        }

        public async Task RemovePregunta(Pregunta pregunta)
        {
            _preguntaRepository.RemovePregunta(pregunta);
        }
    }
}

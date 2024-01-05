using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IPreguntaService
    {
        Task<Pregunta> GetPreguntaByIdAsync(int id);
        Task<IEnumerable<Pregunta>> GetAllPreguntasAsync();
        Task AddPregunta(Pregunta pregunta);
        Task UpdatePregunta(Pregunta pregunta);
        Task RemovePregunta(Pregunta pregunta);
    }
}

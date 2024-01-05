using Domain.Models;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class AspiranteService : IAspiranteService
    {
        private readonly IAspiranteRepository _aspiranteRepository;

        public AspiranteService(IAspiranteRepository aspiranteRepository)
        {
            _aspiranteRepository = aspiranteRepository ?? throw new ArgumentNullException(nameof(aspiranteRepository));
        }

        public async Task<Aspirante> GetAspiranteByIdAsync(int id)
        {
            return await _aspiranteRepository.GetAspiranteByIdAsync(id);
        }

        public async Task<IEnumerable<Aspirante>> GetAllAspirantesAsync()
        {
            return await _aspiranteRepository.GetAllAspirantesAsync();
        }

        public async Task AddAspirante(Aspirante aspirante)
        {
            _aspiranteRepository.AddAspirante(aspirante);
        }

        public async Task UpdateAspirante(Aspirante aspirante)
        {
            _aspiranteRepository.UpdateAspirante(aspirante);
        }

        public async Task RemoveAspirante(Aspirante aspirante)
        {
            _aspiranteRepository.RemoveAspirante(aspirante);
        }

        public async Task ObtenerReportePorAspiranteAsync(int aspiranteId)
        {
            // Lógica para obtener el informe por aspirante
            await _aspiranteRepository.ObtenerReportePorAspiranteAsync(aspiranteId);
        }

        public async Task ObtenerReporteTodosAspiranteAsync()
        {
            // Lógica para obtener el informe para todos los aspirantes
            await _aspiranteRepository.ObtenerReporteTodosAspiranteAsync();
        }
    }

}

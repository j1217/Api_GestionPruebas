using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IAspiranteService
    {
        Task<Aspirante> GetAspiranteByIdAsync(int id);
        Task<IEnumerable<Aspirante>> GetAllAspirantesAsync();
        Task AddAspirante(Aspirante aspirante);
        Task UpdateAspirante(Aspirante aspirante);
        Task RemoveAspirante(Aspirante aspirante);
        Task ObtenerReportePorAspiranteAsync(int aspiranteId);
        Task ObtenerReporteTodosAspiranteAsync();
    }
}

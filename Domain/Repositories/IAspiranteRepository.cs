using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IAspiranteRepository
{
    Task<Aspirante> GetAspiranteByIdAsync(int id);
    Task<IEnumerable<Aspirante>> GetAllAspirantesAsync();
    Task AddAspirante(Aspirante aspirante);
    Task UpdateAspirante(Aspirante aspirante);
    Task RemoveAspirante(Aspirante aspirante);
    Task ObtenerReportePorAspiranteAsync(int aspiranteId);
    Task ObtenerReporteTodosAspiranteAsync();
}
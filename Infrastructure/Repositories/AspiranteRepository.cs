using Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class AspiranteRepository : IAspiranteRepository
{
    private readonly AppDbContext _dbContext;

    public AspiranteRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<Aspirante> GetAspiranteByIdAsync(int id)
    {
        return await _dbContext.Aspirantes.FindAsync(id);
    }

    public async Task<IEnumerable<Aspirante>> GetAllAspirantesAsync()
    {
        return await _dbContext.Aspirantes.ToListAsync();
    }

    public async Task AddAspirante(Aspirante aspirante)
    {
        _dbContext.Aspirantes.Add(aspirante);
    }

    public async Task UpdateAspirante(Aspirante aspirante)
    {
        _dbContext.Entry(aspirante).State = EntityState.Modified;
    }

    public async Task RemoveAspirante(Aspirante aspirante)
    {
        _dbContext.Aspirantes.Remove(aspirante);
    }
    public async Task ObtenerReportePorAspiranteAsync(int aspiranteId)
    {
        var parameters = new SqlParameter("@AspiranteID", aspiranteId);

        await _dbContext.ExportarReportePorAspiranteCSVAsync(aspiranteId);
    }
    public async Task ObtenerReporteTodosAspiranteAsync()
    {
        await _dbContext.ExportarReporteParaTodosAspirantesCSVAsync();
    }
}

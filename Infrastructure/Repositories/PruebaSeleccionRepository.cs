using Domain.Models;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class PruebaSeleccionRepository : IPruebaSeleccionRepository
{
    private readonly AppDbContext _dbContext;

    public PruebaSeleccionRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<PruebaSeleccion> GetPruebaSeleccionByIdAsync(int id)
    {
        return await _dbContext.PruebasSeleccion.FindAsync(id);
    }

    public async Task<IEnumerable<PruebaSeleccion>> GetAllPruebasSeleccionAsync()
    {
        return await _dbContext.PruebasSeleccion.ToListAsync();
    }

    public async Task AddPruebaSeleccion(PruebaSeleccion pruebaSeleccion)
    {
        _dbContext.PruebasSeleccion.Add(pruebaSeleccion);
    }

    public async Task UpdatePruebaSeleccion(PruebaSeleccion pruebaSeleccion)
    {
        _dbContext.Entry(pruebaSeleccion).State = EntityState.Modified;
    }

    public async Task RemovePruebaSeleccion(PruebaSeleccion pruebaSeleccion)
    {
        _dbContext.PruebasSeleccion.Remove(pruebaSeleccion);
    }
}

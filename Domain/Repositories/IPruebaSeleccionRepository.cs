using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IPruebaSeleccionRepository
    {
        Task<PruebaSeleccion> GetPruebaSeleccionByIdAsync(int id);
        Task<IEnumerable<PruebaSeleccion>> GetAllPruebasSeleccionAsync();
        Task AddPruebaSeleccion(PruebaSeleccion pruebaSeleccion);
        Task UpdatePruebaSeleccion(PruebaSeleccion pruebaSeleccion);
        Task RemovePruebaSeleccion(PruebaSeleccion pruebaSeleccion);
    }
}

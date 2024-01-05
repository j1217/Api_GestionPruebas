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
    public class PruebaSeleccionService : IPruebaSeleccionService
    {
        private readonly IPruebaSeleccionRepository _pruebaSeleccionRepository;

        public PruebaSeleccionService(IPruebaSeleccionRepository pruebaSeleccionRepository)
        {
            _pruebaSeleccionRepository = pruebaSeleccionRepository ?? throw new ArgumentNullException(nameof(pruebaSeleccionRepository));
        }

        public async Task<PruebaSeleccion> GetPruebaSeleccionByIdAsync(int id)
        {
            return await _pruebaSeleccionRepository.GetPruebaSeleccionByIdAsync(id);
        }

        public async Task<IEnumerable<PruebaSeleccion>> GetAllPruebasSeleccionAsync()
        {
            return await _pruebaSeleccionRepository.GetAllPruebasSeleccionAsync();
        }

        public async Task AddPruebaSeleccion(PruebaSeleccion pruebaSeleccion)
        {
            _pruebaSeleccionRepository.AddPruebaSeleccion(pruebaSeleccion);
        }

        public async Task UpdatePruebaSeleccion(PruebaSeleccion pruebaSeleccion)
        {
            _pruebaSeleccionRepository.UpdatePruebaSeleccion(pruebaSeleccion);
        }

        public async Task RemovePruebaSeleccion(PruebaSeleccion pruebaSeleccion)
        {
            _pruebaSeleccionRepository.RemovePruebaSeleccion(pruebaSeleccion);
        }
    }

}

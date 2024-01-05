using Application.DTO;
using Application.Extensions;
using Domain.Models;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api_GestionPruebas.Controllers
{
    [ApiController]
    [Route("api/pruebasseleccion")]
    public class PruebaSeleccionController : ControllerBase
    {
        private readonly IPruebaSeleccionService _pruebaSeleccionService;

        public PruebaSeleccionController(IPruebaSeleccionService pruebaSeleccionService)
        {
            _pruebaSeleccionService = pruebaSeleccionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PruebaSeleccionDTO>>> GetAllPruebasSeleccion()
        {
            var pruebasSeleccion = await _pruebaSeleccionService.GetAllPruebasSeleccionAsync();
            return Ok(pruebasSeleccion.Select(p => p.ToDTO()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PruebaSeleccionDTO>> GetPruebaSeleccionById(int id)
        {
            var pruebaSeleccion = await _pruebaSeleccionService.GetPruebaSeleccionByIdAsync(id);

            if (pruebaSeleccion == null)
                return NotFound();

            return Ok(pruebaSeleccion.ToDTO());
        }

        [HttpPost]
        public async Task<ActionResult> AddPruebaSeleccion([FromBody] PruebaSeleccionDTO pruebaSeleccionDTO)
        {
            var pruebaSeleccion = new PruebaSeleccion
            {
                NombreDescripcion = pruebaSeleccionDTO.NombreDescripcion,
                AspiranteId = pruebaSeleccionDTO.AspiranteId,
                FechaInicio = pruebaSeleccionDTO.FechaInicio,
                FechaFinalizacion = pruebaSeleccionDTO.FechaFinalizacion,
                TipoPrueba = pruebaSeleccionDTO.TipoPrueba,
                LenguajeProgramacion = pruebaSeleccionDTO.LenguajeProgramacion,
                CantidadPreguntas = pruebaSeleccionDTO.CantidadPreguntas,
                Nivel = pruebaSeleccionDTO.Nivel,
                EstadoPrueba = pruebaSeleccionDTO.EstadoPrueba
            };

            await _pruebaSeleccionService.AddPruebaSeleccion(pruebaSeleccion);
            return CreatedAtAction(nameof(GetPruebaSeleccionById), new { id = pruebaSeleccion.Id }, pruebaSeleccion.ToDTO());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePruebaSeleccion(int id, [FromBody] PruebaSeleccionDTO pruebaSeleccionDTO)
        {
            var existingPruebaSeleccion = await _pruebaSeleccionService.GetPruebaSeleccionByIdAsync(id);

            if (existingPruebaSeleccion == null)
                return NotFound();

            existingPruebaSeleccion.NombreDescripcion = pruebaSeleccionDTO.NombreDescripcion;
            existingPruebaSeleccion.AspiranteId = pruebaSeleccionDTO.AspiranteId;
            existingPruebaSeleccion.FechaInicio = pruebaSeleccionDTO.FechaInicio;
            existingPruebaSeleccion.FechaFinalizacion = pruebaSeleccionDTO.FechaFinalizacion;
            existingPruebaSeleccion.TipoPrueba = pruebaSeleccionDTO.TipoPrueba;
            existingPruebaSeleccion.LenguajeProgramacion = pruebaSeleccionDTO.LenguajeProgramacion;
            existingPruebaSeleccion.CantidadPreguntas = pruebaSeleccionDTO.CantidadPreguntas;
            existingPruebaSeleccion.Nivel = pruebaSeleccionDTO.Nivel;
            existingPruebaSeleccion.EstadoPrueba = pruebaSeleccionDTO.EstadoPrueba;

            await _pruebaSeleccionService.UpdatePruebaSeleccion(existingPruebaSeleccion);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemovePruebaSeleccion(int id)
        {
            var existingPruebaSeleccion = await _pruebaSeleccionService.GetPruebaSeleccionByIdAsync(id);

            if (existingPruebaSeleccion == null)
                return NotFound();

            await _pruebaSeleccionService.RemovePruebaSeleccion(existingPruebaSeleccion);
            return NoContent();
        }
    }

}

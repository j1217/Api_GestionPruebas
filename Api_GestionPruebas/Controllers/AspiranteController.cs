using Application.DTO;
using Application.Extensions;
using Domain.Models;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api_GestionPruebas.Controllers
{
    [ApiController]
    [Route("api/aspirantes")]
    public class AspiranteController : ControllerBase
    {
        private readonly IAspiranteService _aspiranteService;

        public AspiranteController(IAspiranteService aspiranteService)
        {
            _aspiranteService = aspiranteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AspiranteDTO>>> GetAllAspirantes()
        {
            var aspirantes = await _aspiranteService.GetAllAspirantesAsync();
            return Ok(aspirantes.Select(a => a.ToDTO()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AspiranteDTO>> GetAspiranteById(int id)
        {
            var aspirante = await _aspiranteService.GetAspiranteByIdAsync(id);

            if (aspirante == null)
                return NotFound();

            return Ok(aspirante.ToDTO());
        }

        [HttpPost]
        public async Task<ActionResult> AddAspirante([FromBody] AspiranteDTO aspiranteDTO)
        {
            var aspirante = new Aspirante
            {
                Nombre = aspiranteDTO.Nombre,
                Apellido = aspiranteDTO.Apellido,
                DatosContacto = aspiranteDTO.DatosContacto,
                EstadoPrueba = aspiranteDTO.EstadoPrueba,
                Calificacion = aspiranteDTO.Calificacion
            };

            await _aspiranteService.AddAspirante(aspirante);
            return CreatedAtAction(nameof(GetAspiranteById), new { id = aspirante.Id }, aspirante.ToDTO());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAspirante(int id, [FromBody] AspiranteDTO aspiranteDTO)
        {
            var existingAspirante = await _aspiranteService.GetAspiranteByIdAsync(id);

            if (existingAspirante == null)
                return NotFound();

            existingAspirante.Nombre = aspiranteDTO.Nombre;
            existingAspirante.Apellido = aspiranteDTO.Apellido;
            existingAspirante.DatosContacto = aspiranteDTO.DatosContacto;
            existingAspirante.EstadoPrueba = aspiranteDTO.EstadoPrueba;
            existingAspirante.Calificacion = aspiranteDTO.Calificacion;

            await _aspiranteService.UpdateAspirante(existingAspirante);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveAspirante(int id)
        {
            var existingAspirante = await _aspiranteService.GetAspiranteByIdAsync(id);

            if (existingAspirante == null)
                return NotFound();

            await _aspiranteService.RemoveAspirante(existingAspirante);
            return NoContent();
        }

        [HttpGet("reporte/{id}")]
        public async Task<ActionResult> ObtenerReportePorAspirante(int id)
        {
            try
            {
                await _aspiranteService.ObtenerReportePorAspiranteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("reporte")]
        public async Task<ActionResult> ObtenerReporteTodosAspirantes()
        {
            try
            {
                await _aspiranteService.ObtenerReporteTodosAspiranteAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }


}

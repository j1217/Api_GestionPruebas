using Application.DTO;
using Application.Extensions;
using Domain.Models;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api_GestionPruebas.Controllers
{
    [ApiController]
    [Route("api/preguntas")]
    public class PreguntaController : ControllerBase
    {
        private readonly IPreguntaService _preguntaService;

        public PreguntaController(IPreguntaService preguntaService)
        {
            _preguntaService = preguntaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PreguntaDTO>>> GetAllPreguntas()
        {
            var preguntas = await _preguntaService.GetAllPreguntasAsync();
            return Ok(preguntas.Select(p => p.ToDTO()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PreguntaDTO>> GetPreguntaById(int id)
        {
            var pregunta = await _preguntaService.GetPreguntaByIdAsync(id);

            if (pregunta == null)
                return NotFound();

            return Ok(pregunta.ToDTO());
        }

        [HttpPost]
        public async Task<ActionResult> AddPregunta([FromBody] PreguntaDTO preguntaDTO)
        {
            var pregunta = new Pregunta
            {
                TextoPregunta = preguntaDTO.TextoPregunta,
                OpcionesRespuesta = preguntaDTO.OpcionesRespuesta,
                RespuestaCorrecta = preguntaDTO.RespuestaCorrecta
            };

            await _preguntaService.AddPregunta(pregunta);
            return CreatedAtAction(nameof(GetPreguntaById), new { id = pregunta.Id }, pregunta.ToDTO());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePregunta(int id, [FromBody] PreguntaDTO preguntaDTO)
        {
            var existingPregunta = await _preguntaService.GetPreguntaByIdAsync(id);

            if (existingPregunta == null)
                return NotFound();

            existingPregunta.TextoPregunta = preguntaDTO.TextoPregunta;
            existingPregunta.OpcionesRespuesta = preguntaDTO.OpcionesRespuesta;
            existingPregunta.RespuestaCorrecta = preguntaDTO.RespuestaCorrecta;

            await _preguntaService.UpdatePregunta(existingPregunta);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemovePregunta(int id)
        {
            var existingPregunta = await _preguntaService.GetPreguntaByIdAsync(id);

            if (existingPregunta == null)
                return NotFound();

            await _preguntaService.RemovePregunta(existingPregunta);
            return NoContent();
        }
    }

}

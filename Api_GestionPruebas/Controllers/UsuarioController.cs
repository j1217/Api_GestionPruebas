using Application.DTO;
using Application.Extensions;
using Domain.Models;
using Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_GestionPruebas.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> GetAllUsuarios()
        {
            var usuarios = await _usuarioService.GetAllUsuariosAsync();
            return Ok(usuarios.Select(u => u.ToDTO()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDTO>> GetUsuarioById(int id)
        {
            var usuario = await _usuarioService.GetUsuarioByIdAsync(id);

            if (usuario == null)
                return NotFound();

            return Ok(usuario.ToDTO());
        }

        [HttpPost]
        public async Task<ActionResult> AddUsuario([FromBody] UsuarioDTO usuarioDTO)
        {
            var usuario = new Usuario
            {
                NombreUsuario = usuarioDTO.NombreUsuario,
                ContraseñaHash = usuarioDTO.ContraseñaHash,
                Rol = usuarioDTO.Rol
            };

            await _usuarioService.AddUsuario(usuario);
            return CreatedAtAction(nameof(GetUsuarioById), new { id = usuario.Id }, usuario.ToDTO());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUsuario(int id, [FromBody] UsuarioDTO usuarioDTO)
        {
            var existingUsuario = await _usuarioService.GetUsuarioByIdAsync(id);

            if (existingUsuario == null)
                return NotFound();

            existingUsuario.NombreUsuario = usuarioDTO.NombreUsuario;
            existingUsuario.ContraseñaHash = usuarioDTO.ContraseñaHash;
            existingUsuario.Rol = usuarioDTO.Rol;

            await _usuarioService.UpdateUsuario(existingUsuario);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveUsuario(int id)
        {
            var existingUsuario = await _usuarioService.GetUsuarioByIdAsync(id);

            if (existingUsuario == null)
                return NotFound();

            await _usuarioService.RemoveUsuario(existingUsuario);
            return NoContent();
        }
    }

}

using Application.DTOs;
using Application.Interfaces;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Presentation.Controllers // Certifique-se que Presentation está correto e faz parte do assembly web
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public async Task<IActionResult> InserirUsuario([FromBody] UsuarioDto usuarioDto)
        {
            var usuarioCriado = await _usuarioService.AdicionarUsuarioAsync(usuarioDto);
            return Ok(usuarioCriado);
        }

        [HttpGet]
        public async Task<IActionResult> ObterUsuarios()
        {
            var usuarios = await _usuarioService.ObterTodosUsuariosAsync();
            return Ok(usuarios);
        }

        [HttpPost("usuarioCpf")]
        public async Task<IActionResult> ObterUsuarioPeloId([FromBody] UsuarioCpfDto usuarioCpfDto)
        {
            var usuario = await _usuarioService.ObterUsuarioPorIdAsync(usuarioCpfDto.Cpf);
            if (usuario == null)
                return NotFound();
            return Ok(usuario);
        }

        [HttpPut("{cpf}")]
        public async Task<IActionResult> AtualizarUsuario([FromRoute] string cpf, [FromBody] UsuarioDto usuarioDto)
        {
            var atualizado = await _usuarioService.AtualizarUsuarioPorCpfAsync(cpf, usuarioDto);
            if (!atualizado)
                return NotFound();
            return Ok(atualizado);
        }
    }   
}

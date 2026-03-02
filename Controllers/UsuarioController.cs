using Application.DTOs;
using Application.Interfaces;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

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
        try
        {
            var usuarioCriado = await _usuarioService.AdicionarUsuarioAsync(usuarioDto);
            return CreatedAtAction(nameof(ObterUsuarioPorCpf), new { cpf = usuarioCriado.Cpf }, usuarioCriado);
        }
        catch (DomainException ex)
        {
            return BadRequest(new { erro = ex.Message });
        }
    }

    [HttpGet]
    public async Task<IActionResult> ObterUsuarios()
    {
        var usuarios = await _usuarioService.ObterTodosUsuariosAsync();
        return Ok(usuarios);
    }

    [HttpGet("{cpf}")]
    public async Task<IActionResult> ObterUsuarioPorCpf([FromRoute] string cpf)
    {
        try
        {
            var usuario = await _usuarioService.ObterUsuarioPorCpfAsync(cpf);
            return Ok(usuario);
        }
        catch (UsuarioNaoEncontradoException)
        {
            return NotFound();
        }
    }

    [HttpPut("{cpf}")]
    public async Task<IActionResult> AtualizarUsuario([FromRoute] string cpf, [FromBody] UsuarioDto usuarioDto)
    {
        try
        {
            await _usuarioService.AtualizarUsuarioPorCpfAsync(cpf, usuarioDto);
            return NoContent();
        }
        catch (UsuarioNaoEncontradoException)
        {
            return NotFound();
        }
        catch (DomainException ex)
        {
            return BadRequest(new { erro = ex.Message });
        }
    }
}

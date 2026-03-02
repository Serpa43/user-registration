using Application.DTOs;

namespace Application.Interfaces;

public interface IUsuarioService
{
    Task<UsuarioDto> AdicionarUsuarioAsync(UsuarioDto usuarioDto);
    Task<List<UsuarioDto>> ObterTodosUsuariosAsync();
    Task<UsuarioDto> ObterUsuarioPorCpfAsync(string cpf);
    Task AtualizarUsuarioPorCpfAsync(string cpf, UsuarioDto usuarioDto);
}

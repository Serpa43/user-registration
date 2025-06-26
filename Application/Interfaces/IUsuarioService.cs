using Application.DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioDto> AdicionarUsuarioAsync(UsuarioDto usuarioDto);
        Task<List<UsuarioDto>> ObterTodosUsuariosAsync();
        Task<UsuarioDto> ObterUsuarioPorIdAsync(string cpf);
        Task<bool> AtualizarUsuarioPorCpfAsync(string cpf, UsuarioDto usuarioDto);
    }
}

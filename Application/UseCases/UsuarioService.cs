using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace Application.UseCases
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<UsuarioDto> AdicionarUsuarioAsync(UsuarioDto usuarioDto)
        {
            var usuario = Usuario.Criar(
                usuarioDto.Nome,
                usuarioDto.Cpf,
                usuarioDto.Rg,
                usuarioDto.DataNascimento,
                usuarioDto.NumeroTelefone
            );

            var usuarioSalvo = await _usuarioRepository.AdicionarAsync(usuario);

            if (usuarioSalvo == null)
                throw new DomainException("Erro ao salvar o usuário.");

            return MapToDto(usuarioSalvo);
        }

        public async Task<List<UsuarioDto>> ObterTodosUsuariosAsync()
        {
            var usuarios = await _usuarioRepository.ObterTodosAsync();
            return usuarios.Select(MapToDto).ToList();
        }

        public async Task<UsuarioDto> ObterUsuarioPorCpfAsync(string cpf)
        {
            var usuario = await _usuarioRepository.ObterPorCpfAsync(cpf);

            if (usuario == null)
                throw new UsuarioNaoEncontradoException(cpf);

            return MapToDto(usuario);
        }

        public async Task AtualizarUsuarioPorCpfAsync(string cpf, UsuarioDto usuarioDto)
        {
            var usuario = await _usuarioRepository.ObterPorCpfAsync(cpf);

            if (usuario == null)
                throw new UsuarioNaoEncontradoException(cpf);

            usuario.Atualizar(usuarioDto.Nome, usuarioDto.DataNascimento, usuarioDto.NumeroTelefone);

            await _usuarioRepository.AtualizarAsync(usuario);
        }

        private static UsuarioDto MapToDto(Usuario usuario)
        {
            return new UsuarioDto
            {
                Nome = usuario.Nome,
                Cpf = usuario.Cpf,
                Rg = usuario.Rg,
                DataNascimento = usuario.DataNascimento,
                NumeroTelefone = usuario.NumeroTelefone
            };
        }
    }
}

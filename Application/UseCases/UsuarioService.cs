using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Repositories;
using System.Threading.Tasks;
using System;
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
            var usuario = new Usuario
            {
                Id = Guid.NewGuid(),
                Nome = usuarioDto.Nome,
                Cpf = usuarioDto.Cpf,
                Rg = usuarioDto.Rg,
                DataNascimento = usuarioDto.DataNascimento,
                NumeroTelefone = usuarioDto.NumeroTelefone
            };
            var usuarioSalvo = await _usuarioRepository.AdicionarAsync(usuario);

            if (usuarioSalvo == null) throw new Exception("Erro ao salvar o usuário.");

            return new UsuarioDto { Nome = usuarioSalvo.Nome, Cpf = usuarioSalvo.Cpf, Rg = usuarioSalvo.Rg, 
                                    DataNascimento = usuarioSalvo.DataNascimento, NumeroTelefone = usuarioSalvo.NumeroTelefone };
        }

        public async Task<List<UsuarioDto>> ObterTodosUsuariosAsync()
        {
            var usuarios = await _usuarioRepository.ObterTodosAsync();

            List<UsuarioDto> usuarioDtos = usuarios.Select(u => new UsuarioDto
            {
                Nome = u.Nome,
                Cpf = u.Cpf,
                Rg = u.Rg,
                DataNascimento = u.DataNascimento,
                NumeroTelefone = u.NumeroTelefone
            }).ToList();
            
            return usuarioDtos;
        }

        public async Task<UsuarioDto> ObterUsuarioPorIdAsync(string cpf)
        {
            var usuario = await _usuarioRepository.ObterPorCpfAsync(cpf);
            if (usuario == null) return null;
            return new UsuarioDto
            {
                Nome = usuario.Nome,
                Cpf = usuario.Cpf,
                Rg = usuario.Rg,
                DataNascimento = usuario.DataNascimento,
                NumeroTelefone = usuario.NumeroTelefone
            };
        }

        public async Task<bool> AtualizarUsuarioPorCpfAsync(string cpf, UsuarioDto usuarioDto)
        {
            var usuario = await _usuarioRepository.ObterPorCpfAsync(cpf);
            if (usuario == null)
                return false;
            // Não permite editar CPF nem RG
            usuario.Nome = usuarioDto.Nome;
            usuario.DataNascimento = usuarioDto.DataNascimento;
            usuario.NumeroTelefone = usuarioDto.NumeroTelefone;
            await _usuarioRepository.AtualizarAsync(usuario);
            return true;
        }
    }
}

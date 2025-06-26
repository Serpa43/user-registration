using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly MyProjectDbContext _context;
        
        public UsuarioRepository(MyProjectDbContext context)
        {
            _context = context;
        }
        public async Task<Usuario> AdicionarAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<List<Usuario>> ObterTodosAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario> ObterPorCpfAsync(string cpf)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(x => x.Cpf == cpf);
        }

        public async Task AtualizarAsync(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
        }
    }
}

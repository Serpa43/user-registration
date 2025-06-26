using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IUsuarioRepository
    {
        Task<Usuario> AdicionarAsync(Usuario usuario);
        Task<List<Usuario>> ObterTodosAsync();
        Task<Usuario> ObterPorCpfAsync(string cpf);
        Task AtualizarAsync(Usuario usuario);
    }
}

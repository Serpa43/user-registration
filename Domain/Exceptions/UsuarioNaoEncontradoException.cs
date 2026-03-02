namespace Domain.Exceptions
{
    public class UsuarioNaoEncontradoException : DomainException
    {
        public UsuarioNaoEncontradoException(string cpf)
            : base($"Usuário com CPF '{cpf}' não encontrado.") { }
    }
}

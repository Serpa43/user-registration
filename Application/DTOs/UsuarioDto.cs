using System;

namespace Application.DTOs
{
    public class UsuarioDto
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public DateTime DataNascimento { get; set; }
        public string NumeroTelefone { get; set; }
    }
}

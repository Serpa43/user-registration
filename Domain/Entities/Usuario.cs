using System;
using Domain.Exceptions;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Usuario
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public string Rg { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string NumeroTelefone { get; private set; }

        private Usuario() { }

        public static Usuario Criar(string nome, string cpf, string rg, DateTime dataNascimento, string numeroTelefone)
        {
            Validar(nome, rg, numeroTelefone);
            var cpfValido = new Cpf(cpf);

            return new Usuario
            {
                Id = Guid.NewGuid(),
                Nome = nome.Trim(),
                Cpf = cpfValido.Valor,
                Rg = rg.Trim(),
                DataNascimento = dataNascimento,
                NumeroTelefone = numeroTelefone.Trim()
            };
        }

        public void Atualizar(string nome, DateTime dataNascimento, string numeroTelefone)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new DomainException("Nome é obrigatório.");

            Nome = nome.Trim();
            DataNascimento = dataNascimento;
            NumeroTelefone = numeroTelefone?.Trim();
        }

        private static void Validar(string nome, string rg, string numeroTelefone)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new DomainException("Nome é obrigatório.");

            if (string.IsNullOrWhiteSpace(rg))
                throw new DomainException("RG é obrigatório.");

            if (string.IsNullOrWhiteSpace(numeroTelefone))
                throw new DomainException("Número de telefone é obrigatório.");
        }
    }
}

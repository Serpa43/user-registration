using System.Linq;
using Domain.Exceptions;

namespace Domain.ValueObjects
{
    public class Cpf
    {
        public string Valor { get; }

        public Cpf(string valor)
        {
            var cpfLimpo = valor?.Replace(".", "").Replace("-", "").Trim();

            if (!IsValid(cpfLimpo))
                throw new DomainException("CPF inválido.");

            Valor = cpfLimpo;
        }

        private static bool IsValid(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf) || cpf.Length != 11)
                return false;

            if (cpf.All(c => c == cpf[0]))
                return false;

            var digitos = cpf.Select(c => c - '0').ToArray();

            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += digitos[i] * (10 - i);

            int resto = soma % 11;
            int primeiroDigito = resto < 2 ? 0 : 11 - resto;

            if (digitos[9] != primeiroDigito)
                return false;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += digitos[i] * (11 - i);

            resto = soma % 11;
            int segundoDigito = resto < 2 ? 0 : 11 - resto;

            return digitos[10] == segundoDigito;
        }

        public override string ToString() => Valor;

        public override bool Equals(object obj)
        {
            if (obj is Cpf other)
                return Valor == other.Valor;
            return false;
        }

        public override int GetHashCode() => Valor.GetHashCode();
    }
}

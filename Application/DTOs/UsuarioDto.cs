namespace Application.DTOs;

public class UsuarioDto
{
    public string Nome { get; set; } = null!;
    public string Cpf { get; set; } = null!;
    public string Rg { get; set; } = null!;
    public DateTime DataNascimento { get; set; }
    public string NumeroTelefone { get; set; } = null!;
}

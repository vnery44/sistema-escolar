namespace SistemaEscolar.Api.DTOs;

public class ResponsavelDoAlunoResponse
{
    public int ResponsavelId { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string Parentesco { get; set; } = string.Empty;
}
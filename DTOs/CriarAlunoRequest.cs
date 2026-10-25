namespace SistemaEscolar.Api.DTOs;

public class CriarAlunoRequest
{
    public int TurmaId { get; set; }
    public string Nome { get; set; } = string.Empty;
    public DateOnly DataNascimento { get; set; }
    public string Matricula { get; set; } = string.Empty;
}
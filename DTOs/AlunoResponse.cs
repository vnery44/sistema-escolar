namespace SistemaEscolar.Api.DTOs;

public class AlunoResponse
{
    public int Id { get; set; }
    public int TurmaId { get; set; }
    public string TurmaNome { get; set; } = string.Empty;
    public string Nome { get; set; } = string.Empty;
    public DateOnly DataNascimento { get; set; }
    public string Matricula { get; set; } = string.Empty;
}
namespace SistemaEscolar.Api.Entities;

public class Aluno
{
    public int Id { get; set; }
    public int TurmaId { get; set; }
    public Turma Turma { get; set; } = null!;
    public string Nome { get; set; } = string.Empty;
    public DateOnly DataNascimento { get; set; }
    public string Matricula { get; set; } = string.Empty;
}
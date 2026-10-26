namespace SistemaEscolar.Api.Entities;

public class AlunoResponsavel
{
    public int AlunoId { get; set; }
    public Aluno Aluno { get; set; } = null!;
    public int ResponsavelId { get; set; }
    public Responsavel Responsavel { get; set; } = null!;
    public string Parentesco { get; set; } = string.Empty;
}
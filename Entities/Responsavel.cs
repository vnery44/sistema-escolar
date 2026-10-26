namespace SistemaEscolar.Api.Entities;

public class Responsavel
{
    public int Id { get; set; }
    public int EscolaId { get; set; }
    public Escola Escola { get; set; } = null!;
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public List<AlunoResponsavel> Alunos { get; set; } = new();
}
namespace SistemaEscolar.Api.Entities;

public class Turma
{
    public int Id { get; set; }
    public int EscolaId { get; set; }
    public Escola Escola { get; set; } = null!;
    public string Nome { get; set; } = string.Empty;
    public int AnoLetivo { get; set; }
}
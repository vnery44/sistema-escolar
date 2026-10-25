namespace SistemaEscolar.Api.Entities;

public class Escola
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Cnpj { get; set; } = string.Empty;
    public List<Turma> Turmas { get; set; } = new();
}
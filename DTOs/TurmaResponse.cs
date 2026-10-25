namespace SistemaEscolar.Api.DTOs;

public class TurmaResponse
{
    public int Id { get; set; }
    public int EscolaId { get; set; }
    public string Nome { get; set; } = string.Empty;
    public int AnoLetivo { get; set; }
}
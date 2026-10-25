namespace SistemaEscolar.Api.DTOs;

public class CriarTurmaRequest
{
    public int EscolaId { get; set; }
    public string Nome { get; set; } = string.Empty;
    public int AnoLetivo { get; set; }
}
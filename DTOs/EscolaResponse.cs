namespace SistemaEscolar.Api.DTOs;

public class EscolaResponse
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Cnpj { get; set; } = string.Empty;
}
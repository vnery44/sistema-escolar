namespace SistemaEscolar.Api.DTOs;

public class ResponsavelResponse
{
    public int Id { get; set; }
    public int EscolaId { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
}
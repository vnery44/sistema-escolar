namespace SistemaEscolar.Api.DTOs;

public class VincularResponsavelRequest
{
    public int ResponsavelId { get; set; }
    public string Parentesco { get; set; } = string.Empty;
}
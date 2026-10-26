using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaEscolar.Api.Data;
using SistemaEscolar.Api.DTOs;
using SistemaEscolar.Api.Entities;

namespace SistemaEscolar.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ResponsaveisController : ControllerBase
{
    private readonly AppDbContext _context;

    public ResponsaveisController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<ResponsavelResponse>>> Listar()
    {
        return await _context.Responsaveis
            .Select(r => new ResponsavelResponse
            {
                Id = r.Id,
                EscolaId = r.EscolaId,
                Nome = r.Nome,
                Email = r.Email,
                Telefone = r.Telefone
            })
            .ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<ResponsavelResponse>> Criar(CriarResponsavelRequest request)
    {
        var escolaExiste = await _context.Escolas.AnyAsync(e => e.Id == request.EscolaId);
        if (!escolaExiste)
        {
            return BadRequest("Escola não encontrada.");
        }

        var responsavel = new Responsavel
        {
            EscolaId = request.EscolaId,
            Nome = request.Nome,
            Email = request.Email,
            Telefone = request.Telefone
        };

        _context.Responsaveis.Add(responsavel);
        await _context.SaveChangesAsync();

        return Ok(new ResponsavelResponse
        {
            Id = responsavel.Id,
            EscolaId = responsavel.EscolaId,
            Nome = responsavel.Nome,
            Email = responsavel.Email,
            Telefone = responsavel.Telefone
        });
    }
}
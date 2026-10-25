using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaEscolar.Api.Data;
using SistemaEscolar.Api.DTOs;
using SistemaEscolar.Api.Entities;

namespace SistemaEscolar.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TurmasController : ControllerBase
{
    private readonly AppDbContext _context;

    public TurmasController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<TurmaResponse>>> Listar()
    {
        return await _context.Turmas
            .Select(t => new TurmaResponse
            {
                Id = t.Id,
                EscolaId = t.EscolaId,
                Nome = t.Nome,
                AnoLetivo = t.AnoLetivo
            })
            .ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<TurmaResponse>> Criar(CriarTurmaRequest request)
    {
        var escolaExiste = await _context.Escolas.AnyAsync(e => e.Id == request.EscolaId);
        if (!escolaExiste)
        {
            return BadRequest("Escola não encontrada.");
        }

        var turma = new Turma
        {
            EscolaId = request.EscolaId,
            Nome = request.Nome,
            AnoLetivo = request.AnoLetivo
        };

        _context.Turmas.Add(turma);
        await _context.SaveChangesAsync();

        return Ok(new TurmaResponse
        {
            Id = turma.Id,
            EscolaId = turma.EscolaId,
            Nome = turma.Nome,
            AnoLetivo = turma.AnoLetivo
        });
    }
}
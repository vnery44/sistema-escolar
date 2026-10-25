using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaEscolar.Api.Data;
using SistemaEscolar.Api.Entities;
using SistemaEscolar.Api.DTOs;

namespace SistemaEscolar.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EscolasController : ControllerBase
{
    private readonly AppDbContext _context;

    public EscolasController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<EscolaResponse>>> Listar()
    {
        return await _context.Escolas
            .Select(e => new EscolaResponse
            {
                Id = e.Id,
                Nome = e.Nome,
                Cnpj = e.Cnpj
            })
            .ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<EscolaResponse>> Criar(CriarEscolaRequest request)
    {
        var escola = new Escola
        {
            Nome = request.Nome,
            Cnpj = request.Cnpj
        };

        _context.Escolas.Add(escola);
        await _context.SaveChangesAsync();

        return Ok(new EscolaResponse
        {
            Id = escola.Id,
            Nome = escola.Nome,
            Cnpj = escola.Cnpj
        });
    }
}
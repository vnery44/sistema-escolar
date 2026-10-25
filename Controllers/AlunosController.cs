using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaEscolar.Api.Data;
using SistemaEscolar.Api.DTOs;
using SistemaEscolar.Api.Entities;

namespace SistemaEscolar.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlunosController : ControllerBase
{
    private readonly AppDbContext _context;

    public AlunosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<AlunoResponse>>> Listar()
    {
        return await _context.Alunos
            .Select(a => new AlunoResponse
            {
                Id = a.Id,
                TurmaId = a.TurmaId,
                TurmaNome = a.Turma.Nome,
                Nome = a.Nome,
                DataNascimento = a.DataNascimento,
                Matricula = a.Matricula
            })
            .ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<AlunoResponse>> Criar(CriarAlunoRequest request)
    {
        var turma = await _context.Turmas.FindAsync(request.TurmaId);
        if (turma is null)
        {
            return BadRequest("Turma não encontrada.");
        }

        var aluno = new Aluno
        {
            TurmaId = request.TurmaId,
            Nome = request.Nome,
            DataNascimento = request.DataNascimento,
            Matricula = request.Matricula
        };

        _context.Alunos.Add(aluno);
        await _context.SaveChangesAsync();

        return Ok(new AlunoResponse
        {
            Id = aluno.Id,
            TurmaId = aluno.TurmaId,
            TurmaNome = turma.Nome,
            Nome = aluno.Nome,
            DataNascimento = aluno.DataNascimento,
            Matricula = aluno.Matricula
        });
    }
}
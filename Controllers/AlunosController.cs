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

    [HttpPost("{alunoId:int}/responsaveis")]
    public async Task<IActionResult> VincularResponsavel(int alunoId, VincularResponsavelRequest request)
    {
        var aluno = await _context.Alunos
            .Include(a => a.Turma)
            .FirstOrDefaultAsync(a => a.Id == alunoId);
        if (aluno is null)
        {
            return NotFound("Aluno não encontrado.");
        }

        var responsavel = await _context.Responsaveis.FindAsync(request.ResponsavelId);
        if (responsavel is null)
        {
            return BadRequest("Responsável não encontrado.");
        }

        if (responsavel.EscolaId != aluno.Turma.EscolaId)
        {
            return BadRequest("O responsável e o aluno pertencem a escolas diferentes.");
        }

        var jaVinculado = await _context.AlunoResponsaveis
            .AnyAsync(ar => ar.AlunoId == alunoId && ar.ResponsavelId == request.ResponsavelId);
        if (jaVinculado)
        {
            return Conflict("Este responsável já está vinculado a este aluno.");
        }

        _context.AlunoResponsaveis.Add(new AlunoResponsavel
        {
            AlunoId = alunoId,
            ResponsavelId = request.ResponsavelId,
            Parentesco = request.Parentesco
        });
        await _context.SaveChangesAsync();

        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpGet("{alunoId:int}/responsaveis")]
    public async Task<ActionResult<List<ResponsavelDoAlunoResponse>>> ListarResponsaveis(int alunoId)
    {
        var alunoExiste = await _context.Alunos.AnyAsync(a => a.Id == alunoId);
        if (!alunoExiste)
        {
            return NotFound("Aluno não encontrado.");
        }

        return await _context.AlunoResponsaveis
            .Where(ar => ar.AlunoId == alunoId)
            .Select(ar => new ResponsavelDoAlunoResponse
            {
                ResponsavelId = ar.ResponsavelId,
                Nome = ar.Responsavel.Nome,
                Email = ar.Responsavel.Email,
                Telefone = ar.Responsavel.Telefone,
                Parentesco = ar.Parentesco
            })
            .ToListAsync();
    }
}
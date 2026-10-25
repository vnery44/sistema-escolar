using Microsoft.EntityFrameworkCore;
using SistemaEscolar.Api.Entities;

namespace SistemaEscolar.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Escola> Escolas => Set<Escola>();
    public DbSet<Turma> Turmas => Set<Turma>();
    public DbSet<Aluno> Alunos => Set<Aluno>();
}
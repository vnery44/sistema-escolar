using Microsoft.EntityFrameworkCore;
using SistemaEscolar.Api.Entities;

namespace SistemaEscolar.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Escola> Escolas => Set<Escola>();
    public DbSet<Turma> Turmas => Set<Turma>();
    public DbSet<Aluno> Alunos => Set<Aluno>();
    public DbSet<Responsavel> Responsaveis => Set<Responsavel>();
    public DbSet<AlunoResponsavel> AlunoResponsaveis => Set<AlunoResponsavel>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AlunoResponsavel>()
            .HasKey(ar => new { ar.AlunoId, ar.ResponsavelId });

        modelBuilder.Entity<Responsavel>()
            .HasOne(r => r.Escola)
            .WithMany()
            .HasForeignKey(r => r.EscolaId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
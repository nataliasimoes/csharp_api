using api_csharp.Data.Map;
using api_csharp.Models;
using Microsoft.EntityFrameworkCore;

namespace api_csharp.Data;

public class SistemaDBContext : DbContext
{
    public SistemaDBContext(DbContextOptions<SistemaDBContext> options) : base(options)
    {
    }

    public DbSet<UsuarioModel> Usuarios { get; set; }
    public DbSet<TarefaModel> Tarefas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsuarioMap());
        modelBuilder.ApplyConfiguration(new  TarefaMap());
        base.OnModelCreating(modelBuilder);
    }
}

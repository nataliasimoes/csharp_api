using api_csharp.Data.Map;
using api_csharp.Models;
using Microsoft.EntityFrameworkCore;

namespace api_csharp.Data;

public class SistemaDBContext : DbContext
{
    public SistemaDBContext(DbContextOptions<SistemaDBContext> options) : base(options)
    {
    }

    public DbSet<UserModel> Usuarios { get; set; }
    public DbSet<TaskModel> Tarefas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserMap());
        modelBuilder.ApplyConfiguration(new  TaskMap());
        base.OnModelCreating(modelBuilder);
    }
}

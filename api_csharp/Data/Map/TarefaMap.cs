using api_csharp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api_csharp.Data.Map;

public class TarefaMap : IEntityTypeConfiguration<TaskModel>
{
    public void Configure(EntityTypeBuilder<TaskModel> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
        builder.Property(x => x.Descricao).HasMaxLength(1000);
        builder.Property(x => x.Status).IsRequired();
        builder.Property(x => x.UsuarioId);

        builder.HasOne(x => x.Usuario);
    }
}

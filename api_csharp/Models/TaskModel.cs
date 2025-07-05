using api_csharp.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_csharp.Models;

public class TaskModel
{
    public int Id { get; set; }
    [Column("Nome")]
    public string? Name { get; set; }
    [Column("Descricao")]
    public string? Description { get; set; }
    public StatusTaskEnum Status { get; set; }
    [Column("UsuarioId")]
    public int? UserId { get; set; } // pode ser nula porque pode ser criada sem usuário e depois ser escolhida por ele
    [Column("DataUltimaAlteracao")]
    public DateTime UpdatedAt { get; set; }
    [Column("DataPrazo")]
    public DateTime? DueDate { get; set; }
    [Column("DataConclusao")]
    public DateTime? CompletedAt { get; set; }

    public virtual UserModel? User { get; set; }
}

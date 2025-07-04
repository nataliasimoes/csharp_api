using api_csharp.Enums;

namespace api_csharp.Models;

public class TaskModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public StatusTaskEnum Status { get; set; }
    public int? UserId { get; set; } // pode ser nula porque pode ser criada sem usuário e depois ser escolhida por ele
    public DateTime UpdatedAt { get; set; }
    public DateTime? DueDate { get; set; }
    public DateTime? CompletedAt { get; set; }

    public virtual UserModel? User { get; set; }
}

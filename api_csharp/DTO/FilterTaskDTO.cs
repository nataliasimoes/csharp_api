using CadastroDeContatos.Enums;
using System.ComponentModel.DataAnnotations;

namespace api_csharp.DTO;

/// <summary>
/// Data transfer object for filtering tasks
/// </summary>
public class FilterTaskDTO
{
    /// <summary>
    /// Filter by task name (partial match)
    /// </summary>
    public string? Nome { get; set; }

    /// <summary>
    /// Filter by task status
    /// Possible values:
    /// 1 = To Do,
    /// 2 = In Progress,
    /// 3 = Completed,
    /// </summary>
    [Range(1, 3, ErrorMessage = "Invalid status")]
    public StatusTaskEnum? Status { get; set; }

    /// <summary>
    /// Filter by assigned user ID
    /// </summary>
    public int? UsuarioId { get; set; }

    /// <summary>
    /// Filter for overdue tasks only
    /// true = Show only overdue tasks,
    /// false = Show only non-overdue tasks,
    /// null = Show all tasks (default)
    /// </summary>
    public bool? TarefaEmAtraso { get; set; }
}
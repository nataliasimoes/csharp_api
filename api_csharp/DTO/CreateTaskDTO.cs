using api_csharp.Enums;
using System.ComponentModel.DataAnnotations;

namespace api_csharp.DTO;

public class CreateTaskDTO
{
    [Required]
    public string Name { get; set; }
    [Required]
    [StringLength(500)]
    public string Description { get; set; }
    [Required]
    [Range(1, 3, ErrorMessage = "Invalid status")]
    public StatusTaskEnum Status { get; set; }
    public int? UserId { get; set; }
    public DateTime? DueDate { get; set; } 
}

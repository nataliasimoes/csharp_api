using CadastroDeContatos.Enums;
using System.ComponentModel.DataAnnotations;

namespace api_csharp.DTO;

public class CreateTaskDTO
{
    [Required]
    public string Nome { get; set; }
    [Required]
    [StringLength(500)]
    public string Descricao { get; set; }
    [Required]
    [Range(1, 3, ErrorMessage = "Invalid status")]
    public StatusTaskEnum Status { get; set; }
    public int? UsuarioId { get; set; }
    public DateTime? DataPrazo { get; set; } 
}

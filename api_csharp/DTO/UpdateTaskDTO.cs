namespace api_csharp.DTO;

public class UpdateTaskDTO
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public int Status { get; set; }
    public int? UsuarioId { get; set; }
    public DateTime? DataPrazo { get; set; } 
    public DateTime? DataConclusao { get; set; }
}

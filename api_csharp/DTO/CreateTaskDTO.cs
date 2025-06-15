namespace api_csharp.DTO;

public class CreateTaskDTO
{
    public string Nome { get; set; }
    public string? Descricao { get; set; }
    public int Status { get; set; }
    public int? UsuarioId { get; set; }  // Pode ser nulo, se a tarefa for criada sem usuário
    public DateTime? DataPrazo { get; set; }  // Definir um prazo, opcional
}

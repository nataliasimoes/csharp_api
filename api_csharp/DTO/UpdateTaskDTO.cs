namespace api_csharp.DTO;

public class UpdateTaskDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Status { get; set; }
    public int? UserId { get; set; }
    public DateTime? DueDate { get; set; } 
    public DateTime? CompletedAt { get; set; }
}

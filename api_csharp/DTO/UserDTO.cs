using System.ComponentModel.DataAnnotations;

namespace api_csharp.DTO;

public class UserDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime UpdatedAt { get; set; }

}

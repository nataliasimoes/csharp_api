using System.ComponentModel.DataAnnotations;

namespace api_csharp.DTO;

public class UserDTO
{
    [Required]
    public string Nome { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}

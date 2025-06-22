using System.ComponentModel.DataAnnotations;

namespace api_csharp.DTO;

public class CreateUserDTO
{
    [Required]
    public string Nome { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    public string Senha { get; set; }
}

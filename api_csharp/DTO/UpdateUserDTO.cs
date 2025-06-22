using System.ComponentModel.DataAnnotations;

namespace api_csharp.DTO;

public class UpdateUserDTO
{
    public string? Nome { get; set; }
    [EmailAddress]
    public string? Email { get; set; }
    public string? Senha { get; set; }
}

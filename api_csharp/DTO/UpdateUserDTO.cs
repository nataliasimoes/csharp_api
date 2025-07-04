using System.ComponentModel.DataAnnotations;

namespace api_csharp.DTO;

public class UpdateUserDTO
{
    public string? Name { get; set; }
    [EmailAddress]
    public string? Email { get; set; }
    public string? Password { get; set; }
}

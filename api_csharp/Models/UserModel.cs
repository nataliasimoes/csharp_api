using System.ComponentModel.DataAnnotations.Schema;

namespace api_csharp.Models;

public class UserModel
{
    public int Id { get; set; }
    [Column("Nome")]
    public string Name { get; set; }
    public string Email { get; set; }
    [Column("Senha")]
    public string Password { get; set; }
    [Column("DataUltimaAlteracao")]
    public DateTime UpdatedAt { get; set; }
}

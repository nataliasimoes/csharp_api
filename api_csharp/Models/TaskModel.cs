using CadastroDeContatos.Enums;

namespace api_csharp.Models;

public class TaskModel
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public StatusTaskEnum Status { get; set; }
    public int? UsuarioId { get; set; } // pode ser nula porque pode ser criada sem usuário e depois ser escolhida por ele
    public DateTime DataUltimaAlteracao { get; set; }
    public DateTime? DataPrazo { get; set; }
    public DateTime? DataConclusao { get; set; }

    public virtual UserModel? Usuario { get; set; }
}

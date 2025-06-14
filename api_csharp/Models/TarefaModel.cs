using CadastroDeContatos.Enums;

namespace api_csharp.Models;

public class TarefaModel
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public StatusTarefaEnum Status { get; set; }
    public int? UsuarioId { get; set; } // pode ser nula porque pode ser criada sem usuário e depois ser escolhida por ele
    public virtual UsuarioModel? Usuario { get; set; }
}

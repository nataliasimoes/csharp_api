using System.ComponentModel;

namespace CadastroDeContatos.Enums;

public enum StatusTarefaEnum
{
    [Description("A fazer")]
    ToDo = 1,

    [Description("Em andamento")]
    InProgress = 2,

    [Description("Concluído")]
    Completed = 3
}

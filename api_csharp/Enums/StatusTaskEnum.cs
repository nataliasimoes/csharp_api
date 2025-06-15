using System.ComponentModel;

namespace CadastroDeContatos.Enums;

public enum StatusTaskEnum
{
    [Description("A fazer")]
    ToDo = 1,

    [Description("Em andamento")]
    InProgress = 2,

    [Description("Concluído")]
    Completed = 3
}

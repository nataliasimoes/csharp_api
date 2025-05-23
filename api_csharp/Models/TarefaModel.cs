﻿using CadastroDeContatos.Enums;

namespace api_csharp.Models;

public class TarefaModel
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public StatusTarefaEnum Status { get; set; }
}

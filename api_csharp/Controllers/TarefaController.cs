using api_csharp.Models;
using api_csharp.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api_csharp.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TarefaController : ControllerBase
{
    public readonly ITarefaRepository _tarefaRepository;

    public TarefaController(ITarefaRepository tarefaRepository)
    {
        _tarefaRepository = tarefaRepository;
    }

    [HttpGet]
    public async Task<ActionResult<List<TarefaModel>>> GetAlltarefa()
    {
        List<TarefaModel> usuarios = await _tarefaRepository.GetAllTasks();

        return Ok(usuarios);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<List<TarefaModel>>> GetAllTasks(int id)
    {
        TarefaModel usuarios = await _tarefaRepository.GetById(id);

        return Ok(usuarios);
    }

    [HttpPost]
    public async Task<ActionResult<TarefaModel>> Createtarefa([FromBody] TarefaModel tarefa)
    {
        TarefaModel tarefaRegistered = await _tarefaRepository.AddTask(tarefa);

        return Ok(tarefaRegistered);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<TarefaModel>> Updatetarefa([FromBody] TarefaModel tarefa, int id)
    {
        tarefa.Id = id;
        TarefaModel tarefaUpdated = await _tarefaRepository.UpdateTask(tarefa, id);

        return Ok(tarefaUpdated);
    }

    // DELETE api/<UsuarioController>/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<TarefaModel>> Delete(int id)
    {
        bool deleted = await _tarefaRepository.Delete(id);

        return Ok(deleted);
    }
}

using api_csharp.Models;
using api_csharp.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api_csharp.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TarefaController : ControllerBase
{
    public readonly ITarefaRepository _taskRepository;

    public TarefaController(ITarefaRepository tarefaRepository)
    {
        _taskRepository = tarefaRepository;
    }

    [HttpGet]
    public async Task<ActionResult<List<TarefaModel>>> GetAlltasks()
    {
        List<TarefaModel> tasks = await _taskRepository.GetAllTasks();

        return Ok(tasks);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<List<TarefaModel>>> GetTaskById(int id)
    {
        TarefaModel tasks = await _taskRepository.GetById(id);

        return Ok(tasks);
    }

    [HttpPost]
    public async Task<ActionResult<TarefaModel>> CreateTask([FromBody] TarefaModel tarefa)
    {
        TarefaModel taskRegistered = await _taskRepository.AddTask(tarefa);

        return Ok(taskRegistered);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<TarefaModel>> UpdateTask([FromBody] TarefaModel tarefa, int id)
    {
        tarefa.Id = id;
        TarefaModel taskUpdated = await _taskRepository.UpdateTask(tarefa, id);

        return Ok(taskUpdated);
    }

    [HttpPut("/api/Tarefa/Complete/{id}")]
    public async Task<ActionResult<TarefaModel>> CompleteTask(int id)
    {
        TarefaModel taskUpdated = await _taskRepository.MarkTaskAsCompleted(id);

        return Ok(taskUpdated);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<TarefaModel>> Delete(int id)
    {
        bool deleted = await _taskRepository.Delete(id);

        return Ok(deleted);
    }
}

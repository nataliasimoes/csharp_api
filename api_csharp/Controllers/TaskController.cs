using api_csharp.DTO;
using api_csharp.Models;
using api_csharp.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api_csharp.Controllers;
[Authorize]
[Route("api/[controller]")]
[ApiController]
public class TaskController : ControllerBase
{
    public readonly ITaskRepository _taskRepository;

    public TaskController(ITaskRepository tarefaRepository)
    {
        _taskRepository = tarefaRepository;
    }

    [HttpGet]
    public async Task<ActionResult<List<TaskModel>>> GetAlltasks()
    {
        List<TaskModel> tasks = await _taskRepository.GetAllTasks();

        return Ok(tasks);
    }

    [HttpGet("/api/Task/Filter")]
    public async Task<ActionResult<List<TaskModel>>> Filtertasks([FromQuery] FilterTaskDTO filter)
    {
        List<TaskModel> tasks = await _taskRepository.FilterTask(filter);

        return Ok(tasks);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<List<TaskModel>>> GetTaskById(int id)
    {
        TaskModel tasks = await _taskRepository.GetById(id);

        return Ok(tasks);
    }

    [HttpPost]
    public async Task<ActionResult<TaskModel>> CreateTask([FromBody] CreateTaskDTO tarefa)
    {
        TaskModel taskRegistered = await _taskRepository.AddTask(tarefa);

        return Ok(taskRegistered);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<TaskModel>> UpdateTask([FromBody] UpdateTaskDTO tarefa, int id)
    {
        TaskModel taskUpdated = await _taskRepository.UpdateTask(tarefa, id);

        return Ok(taskUpdated);
    }

    [HttpPut("/api/Task" +
        "/Complete/{id}")]
    public async Task<ActionResult<TaskModel>> CompleteTask(int id)
    {
        TaskModel taskUpdated = await _taskRepository.MarkTaskAsCompleted(id);

        return Ok(taskUpdated);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<TaskModel>> Delete(int id)
    {
        bool deleted = await _taskRepository.Delete(id);

        return Ok(deleted);
    }
}

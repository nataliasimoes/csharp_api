using api_csharp.Data;
using api_csharp.DTO;
using api_csharp.Models;
using api_csharp.Repository.Interfaces;
using CadastroDeContatos.Enums;
using Microsoft.EntityFrameworkCore;

namespace api_csharp.Repository;

public class TaskRepository : ITaskRepository
{
    // Injeta o Context
    private readonly SistemaDBContext _context;
    public TaskRepository(SistemaDBContext sistemaDBContext)
    {
        _context = sistemaDBContext;
    }

    public async Task<List<TaskModel>> FilterTask(FilterTaskDTO filter)
    {
        var query = _context.Tarefas.AsQueryable();

        if (!string.IsNullOrEmpty(filter.Nome))
        {
            query = query.Where(t => t.Nome.Contains(filter.Nome));
        }

        if (filter.Status.HasValue)
        {
            query = query.Where(t => t.Status == filter.Status.Value);
        }

        if (filter.UsuarioId.HasValue)
        {
            query = query.Where(t => t.UsuarioId == filter.UsuarioId);
        }

        if (filter.TarefaEmAtraso.HasValue)
        {
            if (filter.TarefaEmAtraso.Value)
            {
                query = query.Where(t => !t.DataConclusao.HasValue && t.DataPrazo.HasValue && t.DataPrazo.Value.Date < DateTime.Now);
            }
            else
            {
                query = query.Where(t => t.DataPrazo.HasValue && t.DataPrazo.Value.Date < DateTime.Now || !t.DataPrazo.HasValue);
            }
        }

        return await query.ToListAsync();
    }


    public async Task<List<TaskModel>> GetAllTasks()
    {
        return await _context.Tarefas
            .Include(x => x.Usuario)
            .ToListAsync();
    }

    public async Task<TaskModel> GetById(int id)
    {
        return await _context.Tarefas
            .Include(x => x.Usuario)
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<TaskModel> AddTask(CreateTaskDTO dto)
    {
        var task = new TaskModel
        {
            Nome = dto.Nome,
            Descricao = dto.Descricao,
            Status = (StatusTaskEnum)dto.Status,
            UsuarioId = dto.UsuarioId,
            DataPrazo = dto.DataPrazo,
            DataUltimaAlteracao = DateTime.Now
        };

        await _context.Tarefas.AddAsync(task);
        await _context.SaveChangesAsync();

        return task;
    }

    public async Task<TaskModel> UpdateTask(UpdateTaskDTO task, int id)
    {
        TaskModel taskDb = await GetById(id);

        if (taskDb == null)
        {
            throw new Exception("Tarefa não foi encontrada");
        }

        taskDb.Nome = task.Nome;
        taskDb.Descricao = task.Descricao;
        taskDb.Status = (StatusTaskEnum)task.Status;
        taskDb.UsuarioId = task.UsuarioId;
        taskDb.DataPrazo = task.DataPrazo;
        taskDb.DataConclusao = task.DataConclusao;
        taskDb.DataUltimaAlteracao = DateTime.Now;

        _context.Tarefas.Update(taskDb);
        await _context.SaveChangesAsync();

        return taskDb;
    }

    public async Task<TaskModel> MarkTaskAsCompleted(int id)
    {
        TaskModel taskDb = await GetById(id);

        if (taskDb == null)
        {
            throw new Exception("Tarefa não foi encontrada");
        }

        taskDb.Status = StatusTaskEnum.Completed;
        taskDb.DataConclusao = DateTime.Now;
        taskDb.DataUltimaAlteracao = DateTime.Now;

        _context.Tarefas.Update(taskDb);
        await _context.SaveChangesAsync();

        return taskDb;
    }

    public async Task<bool> Delete(int id)
    {
        TaskModel task = await GetById(id);

        if (task == null)
        {
            throw new Exception("Tarefa não foi encontrada");
        }

        _context.Tarefas.Remove(task);
        await _context.SaveChangesAsync();

        return true;
    }

}

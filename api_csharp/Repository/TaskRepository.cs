using api_csharp.Data;
using api_csharp.DTO;
using api_csharp.Enums;
using api_csharp.Models;
using api_csharp.Repository.Interfaces;
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

        if (!string.IsNullOrEmpty(filter.Name))
        {
            query = query.Where(t => t.Name.Contains(filter.Name));
        }

        if (filter.Status.HasValue)
        {
            query = query.Where(t => t.Status == filter.Status.Value);
        }

        if (filter.UserId.HasValue)
        {
            query = query.Where(t => t.UserId == filter.UserId);
        }

        if (filter.OverdueTask.HasValue)
        {
            if (filter.OverdueTask.Value)
            {
                query = query.Where(t => !t.CompletedAt.HasValue && t.DueDate.HasValue && t.DueDate.Value.Date < DateTime.Now);
            }
            else
            {
                query = query.Where(t => t.DueDate.HasValue && t.DueDate.Value.Date < DateTime.Now || !t.DueDate.HasValue);
            }
        }

        return await query.ToListAsync();
    }


    public async Task<List<TaskModel>> GetAllTasks()
    {
        return await _context.Tarefas
            .Include(x => x.User)
            .ToListAsync();
    }

    public async Task<TaskModel> GetById(int id)
    {
        return await _context.Tarefas
            .Include(x => x.User)
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<TaskModel> AddTask(CreateTaskDTO dto)
    {
        var task = new TaskModel
        {
            Name = dto.Name,
            Description = dto.Description,
            Status = (StatusTaskEnum)dto.Status,
            UserId = dto.UserId,
            DueDate = dto.DueDate,
            UpdatedAt = DateTime.Now
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

        taskDb.Name = task.Name;
        taskDb.Description = task.Description;
        taskDb.Status = (StatusTaskEnum)task.Status;
        taskDb.UserId = task.UserId;
        taskDb.DueDate = task.DueDate;
        taskDb.CompletedAt = task.CompletedAt;
        taskDb.UpdatedAt = DateTime.Now;

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
        taskDb.CompletedAt = DateTime.Now;
        taskDb.UpdatedAt = DateTime.Now;

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

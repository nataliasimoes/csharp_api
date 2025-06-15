using api_csharp.Data;
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
    public async Task<TaskModel> AddTask(TaskModel tarefa)
    {
        tarefa.DataUltimaAlteracao = DateTime.Now;
        await _context.Tarefas.AddAsync(tarefa);
        await _context.SaveChangesAsync();

        return tarefa;
    }
    public async Task<TaskModel> UpdateTask(TaskModel tarefa, int id)
    {
        TaskModel tarefaDb = await GetById(id);

        if (tarefaDb == null)
        {
            throw new Exception("Tarefa não foi encontrada");
        }

        tarefaDb.Nome = tarefa.Nome;
        tarefaDb.Descricao = tarefa.Descricao;
        tarefaDb.Status = tarefa.Status;
        tarefaDb.UsuarioId = tarefa.UsuarioId;
        tarefaDb.DataPrazo = tarefa.DataPrazo;
        tarefaDb.DataConclusao = tarefa.DataConclusao;
        tarefaDb.DataUltimaAlteracao = DateTime.Now;

        _context.Tarefas.Update(tarefaDb);
        await _context.SaveChangesAsync();

        return tarefaDb;
    }

    public async Task<TaskModel> MarkTaskAsCompleted(int id)
    {
        TaskModel tarefaDb = await GetById(id);

        if (tarefaDb == null)
        {
            throw new Exception("Tarefa não foi encontrada");
        }

        tarefaDb.DataConclusao = DateTime.Now;
        tarefaDb.DataUltimaAlteracao = DateTime.Now;

        _context.Tarefas.Update(tarefaDb);
        await _context.SaveChangesAsync();

        return tarefaDb;
    }

    public async Task<bool> Delete(int id)
    {
        TaskModel tarefa = await GetById(id);

        if (tarefa == null)
        {
            throw new Exception("Usuário não foi encontrado");
        }

        _context.Tarefas.Remove(tarefa);
        await _context.SaveChangesAsync();

        return true;
    }

}

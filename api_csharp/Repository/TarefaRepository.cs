using api_csharp.Data;
using api_csharp.Models;
using api_csharp.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api_csharp.Repository;

public class TarefaRepository : ITarefaRepository
{
    // Injeta o Context
    private readonly SistemaDBContext _context;
    public TarefaRepository(SistemaDBContext sistemaDBContext)
    {
        _context = sistemaDBContext;
    }
    public async Task<List<TarefaModel>> GetAllTasks()
    {
        return await _context.Tarefas
            .Include(x => x.Usuario)
            .ToListAsync();
    }

    public async Task<TarefaModel> GetById(int id)
    {
        return await _context.Tarefas
            .Include(x => x.Usuario)
            .FirstOrDefaultAsync(u => u.Id == id);
    }
    public async Task<TarefaModel> AddTask(TarefaModel tarefa)
    {
        await _context.Tarefas.AddAsync(tarefa);
        await _context.SaveChangesAsync();

        return tarefa;
    }
    public async Task<TarefaModel> UpdateTask(TarefaModel tarefa, int id)
    {
        TarefaModel tarefaDb = await GetById(id);

        if (tarefaDb == null)
        {
            throw new Exception("Tarefa não foi encontrada");
        }

        tarefaDb.Nome = tarefa.Nome;
        tarefaDb.Descricao = tarefa.Descricao;
        tarefaDb.Status = tarefa.Status;
        tarefaDb.UsuarioId = tarefa.UsuarioId;

        _context.Tarefas.Update(tarefaDb);
        await _context.SaveChangesAsync();

        return tarefaDb;
    }
    public async Task<bool> Delete(int id)
    {
        TarefaModel tarefa = await GetById(id);

        if (tarefa == null)
        {
            throw new Exception("Usuário não foi encontrado");
        }

        _context.Tarefas.Remove(tarefa);
        await _context.SaveChangesAsync();

        return true;
    }

}

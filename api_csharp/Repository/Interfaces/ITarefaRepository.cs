using api_csharp.Models;

namespace api_csharp.Repository.Interfaces;

public interface ITarefaRepository
{
    Task<List<TarefaModel>> GetAllTasks();
    Task<TarefaModel> GetById(int id);
    Task<TarefaModel> AddTask(TarefaModel task);
    Task<TarefaModel> UpdateTask(TarefaModel task, int id);
    Task<bool> Delete(int id);
}

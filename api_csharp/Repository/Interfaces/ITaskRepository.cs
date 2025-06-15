using api_csharp.Models;

namespace api_csharp.Repository.Interfaces;

public interface ITaskRepository
{
    Task<List<TaskModel>> GetAllTasks();
    Task<TaskModel> GetById(int id);
    Task<TaskModel> AddTask(TaskModel task);
    Task<TaskModel> UpdateTask(TaskModel task, int id);
    Task<TaskModel> MarkTaskAsCompleted(int id);
    Task<bool> Delete(int id);
}

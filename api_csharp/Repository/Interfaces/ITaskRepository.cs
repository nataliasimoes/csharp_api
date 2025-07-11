﻿using api_csharp.DTO;
using api_csharp.Models;

namespace api_csharp.Repository.Interfaces;

public interface ITaskRepository
{
    Task<List<TaskModel>> GetAllTasks();
    Task<TaskModel> GetById(int id);
    Task<List<TaskModel>> FilterTask(FilterTaskDTO filter);
    Task<TaskModel> AddTask(CreateTaskDTO task);
    Task<TaskModel> UpdateTask(UpdateTaskDTO task, int id);
    Task<TaskModel> MarkTaskAsCompleted(int id);
    Task<bool> Delete(int id);
}

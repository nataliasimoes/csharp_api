using api_csharp.DTO;
using api_csharp.Models;

namespace api_csharp.Repository.Interfaces;

public interface IUserRepository
{
    // O Task cria uma função assincrona
    Task<List<UserModel>> GetAllUsers();
    Task<UserModel> GetById(int id);
    Task<UserModel> AddUser(UserDTO usuario);
    Task<UserModel> UpdateUser(UserDTO usuario, int id);
    Task<bool> Delete(int id);
}

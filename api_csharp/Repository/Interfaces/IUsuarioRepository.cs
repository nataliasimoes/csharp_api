using api_csharp.Models;

namespace api_csharp.Repository.Interfaces;

public interface IUsuarioRepository
{
    // O Task cria uma função assincrona
    Task<List<UserModel>> GetAllUsers();
    Task<UserModel> GetById(int id);
    Task<UserModel> AddUser(UserModel usuario);
    Task<UserModel> UpdateUser(UserModel usuario, int id);
    Task<bool> Delete(int id);
}

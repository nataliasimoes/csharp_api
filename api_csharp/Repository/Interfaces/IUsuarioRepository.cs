using api_csharp.Models;

namespace api_csharp.Repository.Interfaces;

public interface IUsuarioRepository
{
    // O Task cria uma função assincrona
    Task<List<UsuarioModel>> GetAllUsers();
    Task<UsuarioModel> GetById(int id);
    Task<UsuarioModel> AddUser(UsuarioModel usuario);
    Task<UsuarioModel> UpdateUser(UsuarioModel usuario, int id);
    Task<bool> Delete(int id);
}

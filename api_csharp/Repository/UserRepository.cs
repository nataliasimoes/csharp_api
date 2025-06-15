using api_csharp.Data;
using api_csharp.DTO;
using api_csharp.Models;
using api_csharp.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace api_csharp.Repository;

public class UserRepository : IUserRepository
{
    // Injeta o Context
    private readonly SistemaDBContext _context;
    public UserRepository(SistemaDBContext sistemaDBContext)
    {
        _context = sistemaDBContext;
    }
    public async Task<List<UserModel>> GetAllUsers()
    {
        return await _context.Usuarios.ToListAsync();
    }

    public async Task<UserModel> GetById(int id)
    {
        return await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
    }
    public async Task<UserModel> AddUser(UserDTO dto)
    {
        var user = new UserModel
        {
            Email = dto.Email,
            Nome = dto.Nome,
            DataUltimaAlteracao = DateTime.Now
        };
        await _context.Usuarios.AddAsync(user);
        await _context.SaveChangesAsync();

        return user;
    }
    public async Task<UserModel> UpdateUser(UserDTO user, int id)
    {
        UserModel userDb = await GetById(id);

        if (userDb == null)
        {
            throw new Exception("Usuário não foi encontrado");
        }

        userDb.Nome = user.Nome;
        userDb.Email = user.Email;
        userDb.DataUltimaAlteracao = DateTime.Now;

        _context.Usuarios.Update(userDb);
        await _context.SaveChangesAsync();

        return userDb;
    }
    public async Task<bool> Delete(int id)
    {
        UserModel user = await GetById(id);

        if (user == null)
        {
            throw new Exception("Usuário não foi encontrado");
        }

        _context.Usuarios.Remove(user);
        await _context.SaveChangesAsync();

        return true;
    }

}

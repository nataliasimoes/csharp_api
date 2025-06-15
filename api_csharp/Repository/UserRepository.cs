using api_csharp.Data;
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
    public async Task<UserModel> AddUser(UserModel usuario)
    {
        usuario.DataUltimaAlteracao = DateTime.Now;
        await _context.Usuarios.AddAsync(usuario);
        await _context.SaveChangesAsync();

        return usuario;
    }
    public async Task<UserModel> UpdateUser(UserModel usuario, int id)
    {
        UserModel usuarioDb = await GetById(id);

        if (usuarioDb == null)
        {
            throw new Exception("Usuário não foi encontrado");
        }

        usuarioDb.Nome = usuario.Nome;
        usuarioDb.Email = usuario.Email;
        usuarioDb.DataUltimaAlteracao = DateTime.Now;

        _context.Usuarios.Update(usuarioDb);
        await _context.SaveChangesAsync();

        return usuarioDb;
    }
    public async Task<bool> Delete(int id)
    {
        UserModel usuario = await GetById(id);

        if (usuario == null)
        {
            throw new Exception("Usuário não foi encontrado");
        }

        _context.Usuarios.Remove(usuario);
        await _context.SaveChangesAsync();

        return true;
    }

}

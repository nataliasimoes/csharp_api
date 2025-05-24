using api_csharp.Data;
using api_csharp.Models;
using api_csharp.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api_csharp.Repository;

public class UsuarioRepository : IUsuarioRepository
{
    // Injeta o Context
    private readonly SistemaDBContext _context;
    public UsuarioRepository(SistemaDBContext sistemaDBContext)
    {
        _context = sistemaDBContext;
    }
    public async Task<List<UsuarioModel>> GetAllUsers()
    {
        return await _context.Usuarios.ToListAsync();
    }

    public async Task<UsuarioModel> GetById(int id)
    {
        return await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
    }
    public async Task<UsuarioModel> AddUser(UsuarioModel usuario)
    {
        await _context.Usuarios.AddAsync(usuario);
        await _context.SaveChangesAsync();

        return usuario;
    }
    public async Task<UsuarioModel> UpdateUser(UsuarioModel usuario, int id)
    {
        UsuarioModel usuarioDb = await GetById(id);

        if (usuarioDb == null)
        {
            throw new Exception("Usuário não foi encontrado");
        }

        usuarioDb.Nome = usuario.Nome;
        usuarioDb.Email = usuario.Email;

        _context.Usuarios.Update(usuarioDb);
        await _context.SaveChangesAsync();

        return usuarioDb;
    }
    public async Task<bool> Delete(int id)
    {
        UsuarioModel usuario = await GetById(id);

        if (usuario == null)
        {
            throw new Exception("Usuário não foi encontrado");
        }

        _context.Usuarios.Remove(usuario);
        await _context.SaveChangesAsync();

        return true;
    }

}

﻿using api_csharp.Data;
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

    public async Task<UserModel> AddUser(CreateUserDTO dto)
    {
        var user = new UserModel
        {
            Email = dto.Email,
            Name = dto.Name,
            Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            UpdatedAt = DateTime.Now
        };
        await _context.Usuarios.AddAsync(user);
        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<UserModel> GetByEmail(string email)
    {
        return await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<UserModel> UpdateUser(UpdateUserDTO user, int id)
    {
        UserModel userDb = await GetById(id) ?? throw new Exception("Usuário não foi encontrado");

        userDb.Name = user.Name ?? userDb.Name;
        userDb.Email = user.Email ?? userDb.Email;
        userDb.Password = user.Password != null ? BCrypt.Net.BCrypt.HashPassword(user.Password) : userDb.Password;
        userDb.UpdatedAt = DateTime.Now;

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

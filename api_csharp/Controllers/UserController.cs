using api_csharp.DTO;
using api_csharp.Models;
using api_csharp.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api_csharp.Controllers;
[Authorize]
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    public readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet]
    public async Task<ActionResult<List<UserDTO>>> GetAllUser()
    {
        var usersResult = await _userRepository.GetAllUsers();

        var users = usersResult.Select(u => new UserDTO
        {
            Id = u.Id,
            Nome = u.Nome,
            Email = u.Email,
            DataUltimaAlteracao = u.DataUltimaAlteracao
        }).ToList();

        return Ok(users);
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<UserDTO>> GetUser(int id)
    {
        var userResult = await _userRepository.GetById(id);

        if (userResult == null)
            return NotFound("Usuário não encontrado.");

        var user = new UserDTO
        {
            Id = userResult.Id,
            Nome = userResult.Nome,
            Email = userResult.Email,
            DataUltimaAlteracao = userResult.DataUltimaAlteracao
        };

        return Ok(user);
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<ActionResult<UserDTO>> CreateUser([FromBody] CreateUserDTO user)
    {
        UserModel userRegistered = await _userRepository.AddUser(user);

        var userResult = new UserDTO
        {
            Id = userRegistered.Id,
            Nome = userRegistered.Nome,
            Email = userRegistered.Email,
            DataUltimaAlteracao = userRegistered.DataUltimaAlteracao
        };

        return Ok(userResult);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UserDTO>> UpdateUser([FromBody] UpdateUserDTO user, int id)
    {
        UserModel userUpdated = await _userRepository.UpdateUser(user, id);

        var userResult = new UserDTO
        {
            Id = userUpdated.Id,
            Nome = userUpdated.Nome,
            Email = userUpdated.Email,
            DataUltimaAlteracao = userUpdated.DataUltimaAlteracao
        };

        return Ok(userResult);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<UserModel>> DeleteUser(int id)
    {
        bool deleted = await _userRepository.Delete(id);

        return Ok(deleted);
    }
}

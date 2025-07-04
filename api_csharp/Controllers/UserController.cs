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
            Name = u.Name,
            Email = u.Email,
            UpdatedAt = u.UpdatedAt
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
            Name = userResult.Name,
            Email = userResult.Email,
            UpdatedAt = userResult.UpdatedAt
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
            Name = userRegistered.Name,
            Email = userRegistered.Email,
            UpdatedAt = userRegistered.UpdatedAt
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
            Name = userUpdated.Name,
            Email = userUpdated.Email,
            UpdatedAt = userUpdated.UpdatedAt
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

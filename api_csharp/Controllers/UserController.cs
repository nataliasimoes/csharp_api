using api_csharp.Models;
using api_csharp.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api_csharp.Controllers;
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
    public async Task<ActionResult<List<UserModel>>> GetAllUser()
    {
        List<UserModel> usuarios = await _userRepository.GetAllUsers();

        return Ok(usuarios);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<List<UserModel>>> GetAllUsers(int id)
    {
        UserModel usuarios = await _userRepository.GetById(id);

        return Ok(usuarios);
    }

    [HttpPost]
    public async Task<ActionResult<UserModel>> CreateUser([FromBody] UserModel user)
    {
        UserModel userRegistered = await _userRepository.AddUser(user);

        return Ok(userRegistered);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UserModel>> UpdateUser([FromBody] UserModel user, int id)
    {
        user.Id = id;
        UserModel userUpdated = await _userRepository.UpdateUser(user, id);

        return Ok(userUpdated);
    }

    // DELETE api/<UsuarioController>/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<UserModel>> DeleteUser(int id)
    {
        bool deleted = await _userRepository.Delete(id);

        return Ok(deleted);
    }
}

using api_csharp.Models;
using api_csharp.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api_csharp.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    public readonly IUsuarioRepository _userRepository;

    public UsuarioController(IUsuarioRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet]
    public async Task<ActionResult<List<UsuarioModel>>> GetAllUser()
    {
        List<UsuarioModel> usuarios = await _userRepository.GetAllUsers();

        return Ok(usuarios);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<List<UsuarioModel>>> GetAllUser(int id)
    {
        UsuarioModel usuarios = await _userRepository.GetById(id);

        return Ok(usuarios);
    }

    [HttpPost]
    public async Task<ActionResult<UsuarioModel>> CreateUser([FromBody] UsuarioModel user)
    {
        UsuarioModel userRegistered = await _userRepository.AddUser(user);

        return Ok(userRegistered);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UsuarioModel>> UpdateUser([FromBody] UsuarioModel user, int id)
    {
        user.Id = id;
        UsuarioModel userUpdated = await _userRepository.UpdateUser(user, id);

        return Ok(userUpdated);
    }

    // DELETE api/<UsuarioController>/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<UsuarioModel>> Delete(int id)
    {
        bool deleted = await _userRepository.Delete(id);

        return Ok(deleted);
    }
}

using api_csharp.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api_csharp.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    // GET: api/<UsuarioController>
    [HttpGet]
    public ActionResult<List<UsuarioModel>> GetAllUser()
    {
        List<UsuarioModel> usuarios = new List<UsuarioModel>();

        usuarios.Add(new UsuarioModel() { Id = 1, Email = "natalia@gmail.com", Nome = "Natália Simões"});

        return usuarios;
    }

    // GET api/<UsuarioController>/5
    [HttpGet("{id}")]
    public UsuarioModel Get(int id)
    {
        UsuarioModel usuario =  new UsuarioModel() { Id = 1, Email = "natalia@gmail.com", Nome = "Natália Simões" };
        return usuario;
    }

    // POST api/<UsuarioController>
    [HttpPost]
    public void Post([FromBody] UsuarioModel usuario)
    {

    }

    // PUT api/<UsuarioController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] UsuarioModel usuario)
    {
    }

    // DELETE api/<UsuarioController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}

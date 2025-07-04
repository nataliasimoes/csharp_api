using api_csharp.Models;
using api_csharp.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace api_csharp.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    public readonly IUserRepository _userRepository;
    private readonly IConfiguration _configuration;

    public AuthenticationController(IUserRepository userRepository, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _configuration = configuration;
    }

    [HttpPost("/api/Login")]
    public async Task<IActionResult> Login([FromBody] LoginModel login)
    {
        UserModel user = await _userRepository.GetByEmail(login.Email);

        if (user == null || !BCrypt.Net.BCrypt.Verify(login.Password, user.Password))
        {
            return BadRequest(new { message = "Credenciais inválidas!" });
        }

        var token = GenerateTokenJWT(user);

        return Ok(new { token });
    }

    private string GenerateTokenJWT(UserModel user)
    {
        var secretKey = _configuration["Jwt:Key"];
        var issuer = _configuration["Jwt:Issuer"];
        var audience = _configuration["Jwt:Audience"];

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
        new Claim("login", user.Email),
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
    };

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: credential
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

}

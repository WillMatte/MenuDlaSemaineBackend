using Backend.Application.Service.Interface;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Backend.Domain.Entities;
using MongoDB.Bson;

namespace Backend.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthController(IAuthService authService, IJwtService jwtService) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest loginRequest)
    {
        User user = await authService.Login(loginRequest.Email, loginRequest.Password);
        var token = jwtService.GenerateToken(user);
        return Ok(new { token });
    }

    [HttpPost("signup")]
    public async Task<IActionResult> Signup(RegisterRequest registerRequest)
    {
        User user = Domain.Entities.User.FromRegisterRequest(registerRequest);
        await authService.Signup(user);
        return Created();
    }

    [HttpPost("logout")]
    public IActionResult Logout()
    {
        return Ok();
    }
}
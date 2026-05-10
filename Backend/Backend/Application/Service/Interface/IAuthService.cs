using Backend.Domain.Entities;
using Microsoft.AspNetCore.Identity.Data;

namespace Backend.Application.Service.Interface;

public interface IAuthService
{
    Task<User> Signup(User user);
    Task<User> Login(string email, string password);
}
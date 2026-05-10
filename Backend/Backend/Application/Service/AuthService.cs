using Backend.Application.Service.Interface;
using Backend.Domain.Entities;
using Backend.Domain.Exception;
using Backend.Domain.Helper;
using Backend.Infra.Interfaces;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.Extensions.Options;

namespace Backend.Application.Service;

public class AuthService(IUserRepository userRepository) : IAuthService
{
    
    public async Task<User> Signup(User user)
    {
        EmailHelper.ValidateEmailFormat(user.Email);
        User? duplicateUser = await userRepository.GetByEmail(user.Email);
        if (duplicateUser != null) throw new DulplicateEmailException("Email Already used");
        PasswordHelper.ValidatePasswordFormat(user.Password);
        user.Password = PasswordHelper.HashPassword(user.Password);
        await userRepository.Create(user);
        return user;
    }

    public bool Login(LoginRequest loginRequest)
    {
        
        return true;
    }
}
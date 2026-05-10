using Backend.Domain.Entities;

namespace Backend.Application.Service.Interface;

public interface IJwtService
{
    string GenerateToken(User user);
}
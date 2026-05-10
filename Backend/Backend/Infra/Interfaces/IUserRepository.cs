using Backend.Domain.Entities;

namespace Backend.Infra.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByEmail(string email);
    Task<User?> GetById(Guid id);
    Task Create(User user);
}
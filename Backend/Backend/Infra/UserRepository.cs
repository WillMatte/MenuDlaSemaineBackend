using Backend.Domain.Entities;
using Backend.Domain.Settings;
using Backend.Infra.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Backend.Infra;

public class UserRepository(IMongoClient client, IOptions<MongoDBSettings> settings) : IUserRepository
{
    private readonly IMongoCollection<User> _collection = client
        .GetDatabase(settings.Value.DatabaseName)
        .GetCollection<User>("users");
    
    
    public async Task<User?> GetByEmail(string email)
    {
        return await _collection.Find(u => u.Email == email).FirstOrDefaultAsync();
    }

    public async Task<User?> GetById(Guid id)
    {
        return await _collection.Find(u => u.Id == id).FirstOrDefaultAsync();
    }

    public async Task Create(User user)
    {
        await _collection.InsertOneAsync(user);
    }
}
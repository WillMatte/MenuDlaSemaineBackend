using Backend.Domain.Entities;
using Backend.Domain.Enum;
using Backend.Domain.Settings;
using Backend.Infra.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Backend.Infra;

public class IngredientRepository(IMongoClient client, IOptions<MongoDBSettings> settings) : IIngredientRepository
{
    private readonly IMongoCollection<Ingredient> _collection = client
        .GetDatabase(settings.Value.DatabaseName)
        .GetCollection<Ingredient>("ingredients");


    public async Task<Ingredient> Create(Ingredient ingredient)
    {
        await _collection.InsertOneAsync(ingredient);
        return ingredient;
    }

    public async Task<List<Ingredient>> GetAll()
    {
        return await _collection.Find(_ => true).ToListAsync();
    }

    public async Task<Ingredient?> GetById(Guid id)
    {
        return await _collection.Find(i => i.Id == id).FirstOrDefaultAsync();    
    }

    public async Task<List<Ingredient>> GetByType(IngredientType type)
    {
        return await _collection.Find(i => i.Type == type).ToListAsync();
    }

    public async Task<Ingredient?> GetByName(string name)
    {
        return await _collection.Find(i => i.Name == name).FirstOrDefaultAsync();    
    }

    public async Task Delete(Guid id)
    {
        await _collection.DeleteOneAsync(i => i.Id == id);
    }
}
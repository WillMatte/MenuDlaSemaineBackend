using Backend.Application.Dto;
using Backend.Domain.Entities;
using Backend.Domain.Enum;

namespace Backend.Infra.Interfaces;

public interface IIngredientRepository
{
    Task<Ingredient> Create(Ingredient ingredient);
    Task<List<Ingredient>> GetAll();
    Task<Ingredient?> GetById(Guid id);
    Task<List<Ingredient>> GetByType(IngredientType type);
    Task<Ingredient?> GetByName(string name);
    Task Delete(Guid id);
}
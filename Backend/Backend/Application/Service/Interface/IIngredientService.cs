using Backend.Application.Dto;
using Backend.Domain.Entities;

namespace Backend.Application.Service.Interface;

public interface IIngredientService
{
    Task<IngredientDto> Create(string name, string type);
    Task<List<IngredientDto>> GetAll();
    Task<IngredientDto> GetById(Guid id);
    Task<IngredientDto> GetByName(string name);
    Task<List<IngredientDto>> GetByType(string type);
    Task Delete(Guid id);
}
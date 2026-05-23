using Backend.Application.Dto;
using Backend.Application.Mappers;
using Backend.Application.Service.Interface;
using Backend.Domain.Entities;
using Backend.Domain.Enum;
using Backend.Domain.Exception;
using Backend.Infra.Interfaces;

namespace Backend.Application.Service;

public class IngredientService(IIngredientRepository ingredientRepository) : IIngredientService
{
    public async Task<IngredientDto> Create(string name, string type)
    {
        Ingredient? duplicateIngredient = await ingredientRepository.GetByName(name);
        if (duplicateIngredient != null) throw new DuplicateEntityException("Ingredient already exists");
        if (!Enum.TryParse(type, ignoreCase: true, out IngredientType typeEnum))
            throw new InvalidIngredientTypeException("Invalid ingredient type");
        Ingredient ingredient = new Ingredient(name, typeEnum);
        ingredient = await ingredientRepository.Create(ingredient);
        return ingredient.ToDto();
    }

    public async Task<List<IngredientDto>> GetAll()
    {
        List<Ingredient> ingredients =  await ingredientRepository.GetAll();
        return ingredients.Select(i => i.ToDto()).ToList();
    }

    public async Task<IngredientDto> GetById(Guid id)
    {
        Ingredient? ingredient = await ingredientRepository.GetById(id);
        if (ingredient == null) throw new EntityNotFoundException("Ingredient not found");
        return ingredient.ToDto();
    }

    public async Task<IngredientDto> GetByName(string name)
    {
        Ingredient? ingredient = await ingredientRepository.GetByName(name);
        if (ingredient == null) throw new EntityNotFoundException("Ingredient not found");
        return ingredient.ToDto();
    }

    public async Task<List<IngredientDto>> GetByType(string type)
    {
        if (!Enum.TryParse(type, ignoreCase: true, out IngredientType typeEnum))
            throw new InvalidIngredientTypeException("Invalid ingredient type"); 
        List<Ingredient> ingredients = await ingredientRepository.GetByType(typeEnum);
        return ingredients.Select(i => i.ToDto()).ToList();
    }

    public async Task Delete(Guid id)
    {
        Ingredient? ingredient = await ingredientRepository.GetById(id);
        if (ingredient == null) throw new EntityNotFoundException("Ingredient not found");
        await ingredientRepository.Delete(id);
    }
}
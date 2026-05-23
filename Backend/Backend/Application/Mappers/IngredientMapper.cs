using Backend.Application.Dto;
using Backend.Domain.Entities;

namespace Backend.Application.Mappers;

public static class IngredientMapper
{
    public static IngredientDto ToDto(this Ingredient ingredient) => new()
    {
        Id = ingredient.Id,
        Name = ingredient.Name,
        Type = ingredient.Type
    };
}
using Backend.Domain.Enum;

namespace Backend.Application.Dto;

public class IngredientDto
{
    public Guid? Id { get; set; }
    public string Name { get; set; }
    public IngredientType Type { get; set; }
}
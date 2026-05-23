using Backend.Domain.Enum;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Backend.Domain.Entities;

public class Recipe
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public Guid? Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public RecipeType Type { get; set; }
    public List<RecipeIngredient> Ingredients { get; set; }
    public string? Image { get; set; }
    public List<string> Instructions { get; set; }
    public TimeSpan PreparationTime { get; set; }
    public TimeSpan CookingTime { get; set; }
    public TimeSpan TotalTime => PreparationTime + CookingTime;
}
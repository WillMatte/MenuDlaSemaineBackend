using Backend.Domain.Enum;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Backend.Domain.Entities;

public class Ingredient
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public Guid? Id { get; set; }
    public string Name { get; set; }
    public IngredientType Type { get; set; }

    public Ingredient(string name, IngredientType type)
    {
        Id = Guid.NewGuid();
        Name = name;
        Type = type;
    }
}
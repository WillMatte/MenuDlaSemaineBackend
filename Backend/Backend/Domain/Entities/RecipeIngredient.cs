using Backend.Domain.Enum;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Backend.Domain.Entities;

public class RecipeIngredient
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public Guid? Id { get; set; }
    public double Quantity { get; set; }
    public MeasurementUnit Unit { get; set; }
    public IngredientImportance Importance { get; set; }
    public bool Optional { get; set; }
    public string? Notes { get; set; }
}
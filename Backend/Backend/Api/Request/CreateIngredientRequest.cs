using System.ComponentModel.DataAnnotations;

namespace Backend.Api.Request;

public class CreateIngredientRequest
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Type { get; set; }
}
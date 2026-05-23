using Backend.Api.Request;
using Backend.Application.Dto;
using Backend.Application.Service.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers;

[ApiController]
[Route("ingredient")]
public class IngredientController(IIngredientService ingredientService) : ControllerBase
{
    [HttpPost("")]
    public async Task<IActionResult> CreateIngredient(CreateIngredientRequest request)
    {
        IngredientDto ingredientDto = await ingredientService.Create(request.Name,request.Type);
        return Created($"/ingredient/{ingredientDto.Id}", ingredientDto);
    }

    [HttpGet("")]
    public async Task<IActionResult> GetAllIngredients()
    {
        var ingredients = await ingredientService.GetAll();
        return Ok(ingredients);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetIngredientById(Guid id)
    {
        var ingredient = await ingredientService.GetById(id);
        return Ok(ingredient);
    }

    [HttpGet("type/{type}")]
    public async Task<IActionResult> GetIngredientByType(string type)
    {
        var ingredient = await ingredientService.GetByType(type);
        return Ok(ingredient);
    }

    [HttpGet("name/{name}")]
    public async Task<IActionResult> GetIngredientByName(string name)
    {
        var ingredient = await ingredientService.GetByName(name);
        return Ok(ingredient);
    }
    
}
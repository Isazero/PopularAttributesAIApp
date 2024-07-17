using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PopularAttributesAIApp.Models;
using PopularAttributesAIApp.Services;

namespace PopularAttributesAIApp.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly AttributeService _attributeService;

    public CategoryController(AttributeService attributeService)
    {
        _attributeService = attributeService;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] List<Category> categories)
    {
        if (categories == null || !categories.Any())
        {
            return BadRequest("The categories list is required.");
        }
        var popularCategories = new List<PopularCategory>();

        foreach (var subCategory in categories.SelectMany(category => category.SubCategories))
        {
            var attributes = await _attributeService.GetPopularAttributesAsync(subCategory);
            popularCategories.Add(new PopularCategory
            {
                CategoryId = subCategory.CategoryId,
                Attributes = attributes
            });
        }

        return Ok(popularCategories);
    }
}
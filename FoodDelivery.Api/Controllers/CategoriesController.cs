using Microsoft.AspNetCore.Mvc;
using FoodDelivery.Application.Services;
using FoodDelivery.Contracts.Categories;

namespace FoodDelivery.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<CategoryDto>), StatusCodes.Status200OK)]
    public IActionResult GetAll() => Ok(_categoryService.GetAll());

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(CategoryDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById(int id)
    {
        var category = _categoryService.GetById(id);
        return category is null ? NotFound(new { Message = $"Категория с Id = {id} не найдена." }) : Ok(category);
    }

    [HttpPost]
    [ProducesResponseType(typeof(CategoryDto), StatusCodes.Status201Created)]
    public IActionResult Create([FromBody] CategoryCreateUpdateDto dto)
    {
        var created = _categoryService.Create(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Update(int id, [FromBody] CategoryCreateUpdateDto dto)
    {
        return _categoryService.Update(id, dto) ? NoContent() : NotFound(new { Message = $"Категория с Id = {id} не найдена." });
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Delete(int id)
    {
        _categoryService.Delete(id);
        return NoContent();
    }
}
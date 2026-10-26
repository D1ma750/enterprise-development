using Microsoft.AspNetCore.Mvc;
using FoodDelivery.Application.Services;
using FoodDelivery.Contracts.Dishes;

namespace FoodDelivery.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DishesController : ControllerBase
{
    private readonly IDishService _dishService;

    public DishesController(IDishService dishService)
    {
        _dishService = dishService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<DishDto>), StatusCodes.Status200OK)]
    public IActionResult GetAll() => Ok(_dishService.GetAll());

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(DishDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById(int id)
    {
        var dish = _dishService.GetById(id);
        return dish is null ? NotFound(new { Message = $"Блюдо с Id = {id} не найдено." }) : Ok(dish);
    }

    [HttpPost]
    [ProducesResponseType(typeof(DishDto), StatusCodes.Status201Created)]
    public IActionResult Create([FromBody] DishCreateUpdateDto dto)
    {
        var created = _dishService.Create(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Update(int id, [FromBody] DishCreateUpdateDto dto)
    {
        return _dishService.Update(id, dto) ? NoContent() : NotFound(new { Message = $"Блюдо с Id = {id} не найдено." });
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Delete(int id)
    {
        _dishService.Delete(id);
        return NoContent();
    }
}
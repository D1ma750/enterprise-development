using Microsoft.AspNetCore.Mvc;
using FoodDelivery.Application.Services;
using FoodDelivery.Contracts.Restaurants;

namespace FoodDelivery.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RestaurantsController : ControllerBase
{
    private readonly IRestaurantService _restaurantService;

    public RestaurantsController(IRestaurantService restaurantService)
    {
        _restaurantService = restaurantService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<RestaurantDto>), StatusCodes.Status200OK)]
    public IActionResult GetAll() => Ok(_restaurantService.GetAll());

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(RestaurantDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById(int id)
    {
        var restaurant = _restaurantService.GetById(id);
        return restaurant is null ? NotFound(new { Message = $"Ресторан с Id = {id} не найден." }) : Ok(restaurant);
    }

    [HttpPost]
    [ProducesResponseType(typeof(RestaurantDto), StatusCodes.Status201Created)]
    public IActionResult Create([FromBody] RestaurantCreateUpdateDto dto)
    {
        var created = _restaurantService.Create(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Update(int id, [FromBody] RestaurantCreateUpdateDto dto)
    {
        return _restaurantService.Update(id, dto) ? NoContent() : NotFound(new { Message = $"Ресторан с Id = {id} не найден." });
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Delete(int id)
    {
        _restaurantService.Delete(id);
        return NoContent();
    }
}
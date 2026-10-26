using Microsoft.AspNetCore.Mvc;
using FoodDelivery.Application.Services;
using FoodDelivery.Contracts.Orders;

namespace FoodDelivery.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<OrderDto>), StatusCodes.Status200OK)]
    public IActionResult GetAll() => Ok(_orderService.GetAll());

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(OrderDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById(int id)
    {
        var order = _orderService.GetById(id);
        if (order is null)
        {
            return NotFound(new { Message = $"Заказ с Id = {id} не найден." });
        }
        return Ok(order);
    }

    [HttpPost]
    [ProducesResponseType(typeof(OrderDto), StatusCodes.Status201Created)]
    public IActionResult Create([FromBody] OrderCreateUpdateDto dto)
    {
        var created = _orderService.Create(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Update(int id, [FromBody] OrderCreateUpdateDto dto)
    {
        var updated = _orderService.Update(id, dto);
        if (!updated)
        {
            return NotFound(new { Message = $"Не удалось обновить: заказ с Id = {id} не найден." });
        }
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Delete(int id)
    {
        _orderService.Delete(id);
        return NoContent();
    }
}
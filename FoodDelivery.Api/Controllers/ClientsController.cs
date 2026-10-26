using Microsoft.AspNetCore.Mvc;
using FoodDelivery.Application.Services;
using FoodDelivery.Contracts.Clients;

namespace FoodDelivery.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientsController : ControllerBase
{
    private readonly IClientService _clientService;

    public ClientsController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<ClientDto>), StatusCodes.Status200OK)]
    public IActionResult GetAll() => Ok(_clientService.GetAll());

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(ClientDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById(int id)
    {
        var client = _clientService.GetById(id);
        return client is null ? NotFound(new { Message = $"Клиент с Id = {id} не найден." }) : Ok(client);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ClientDto), StatusCodes.Status201Created)]
    public IActionResult Create([FromBody] ClientCreateUpdateDto dto)
    {
        var created = _clientService.Create(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Update(int id, [FromBody] ClientCreateUpdateDto dto)
    {
        return _clientService.Update(id, dto) ? NoContent() : NotFound(new { Message = $"Клиент с Id = {id} не найден." });
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Delete(int id)
    {
        _clientService.Delete(id);
        return NoContent();
    }
}
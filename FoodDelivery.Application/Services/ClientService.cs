using Microsoft.Extensions.Logging;
using FoodDelivery.Application.Repositories;
using FoodDelivery.Contracts.Clients;
using FoodDelivery.Domain.Entities;

namespace FoodDelivery.Application.Services;

public class ClientService : IClientService
{
    private readonly IRepository<Client> _repository;
    private readonly ILogger<ClientService> _logger;

    public ClientService(IRepository<Client> repository, ILogger<ClientService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public IReadOnlyList<ClientDto> GetAll() =>
        _repository.GetAll().Select(c => new ClientDto(c.Id, c.FullName, c.Phone, c.DeliveryAddress)).ToList();

    public ClientDto? GetById(int id)
    {
        var entity = _repository.GetById(id);
        return entity is null ? null : new ClientDto(entity.Id, entity.FullName, entity.Phone, entity.DeliveryAddress);
    }

    public ClientDto Create(ClientCreateUpdateDto dto)
    {
        var entity = new Client
        {
            FullName = dto.FullName,
            Phone = dto.Phone,
            DeliveryAddress = dto.DeliveryAddress
        };
        var created = _repository.Create(entity);
        _logger.LogInformation("Создан клиент с Id = {Id}", created.Id);
        return new ClientDto(created.Id, created.FullName, created.Phone, created.DeliveryAddress);
    }

    public bool Update(int id, ClientCreateUpdateDto dto)
    {
        var existing = _repository.GetById(id);
        if (existing is null) return false;

        existing.FullName = dto.FullName;
        existing.Phone = dto.Phone;
        existing.DeliveryAddress = dto.DeliveryAddress;

        var result = _repository.Update(existing);
        _logger.LogInformation("Обновлен клиент с Id = {Id}", id);
        return result;
    }

    public void Delete(int id)
    {
        _repository.Delete(id);
        _logger.LogInformation("Удален клиент с Id = {Id}", id);
    }
}
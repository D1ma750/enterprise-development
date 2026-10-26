using Microsoft.Extensions.Logging;
using FoodDelivery.Application.Repositories;
using FoodDelivery.Contracts.Restaurants;
using FoodDelivery.Domain.Entities;

namespace FoodDelivery.Application.Services;

public class RestaurantService : IRestaurantService
{
    private readonly IRepository<Restaurant> _repository;
    private readonly ILogger<RestaurantService> _logger;

    public RestaurantService(IRepository<Restaurant> repository, ILogger<RestaurantService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public IReadOnlyList<RestaurantDto> GetAll() =>
        _repository.GetAll().Select(r => new RestaurantDto(r.Id, r.Name, r.Address, r.Rating, r.OpenTime, r.CloseTime)).ToList();

    public RestaurantDto? GetById(int id)
    {
        var r = _repository.GetById(id);
        return r is null ? null : new RestaurantDto(r.Id, r.Name, r.Address, r.Rating, r.OpenTime, r.CloseTime);
    }

    public RestaurantDto Create(RestaurantCreateUpdateDto dto)
    {
        var entity = new Restaurant
        {
            Name = dto.Name,
            Address = dto.Address,
            Rating = dto.Rating,
            OpenTime = dto.OpenTime,
            CloseTime = dto.CloseTime
        };
        var created = _repository.Create(entity);
        _logger.LogInformation("Создан ресторан с Id = {Id}", created.Id);
        return new RestaurantDto(created.Id, created.Name, created.Address, created.Rating, created.OpenTime, created.CloseTime);
    }

    public bool Update(int id, RestaurantCreateUpdateDto dto)
    {
        var existing = _repository.GetById(id);
        if (existing is null) return false;

        existing.Name = dto.Name;
        existing.Address = dto.Address;
        existing.Rating = dto.Rating;
        existing.OpenTime = dto.OpenTime;
        existing.CloseTime = dto.CloseTime;

        var result = _repository.Update(existing);
        _logger.LogInformation("Обновлен ресторан с Id = {Id}", id);
        return result;
    }

    public void Delete(int id)
    {
        _repository.Delete(id);
        _logger.LogInformation("Удален ресторан с Id = {Id}", id);
    }
}
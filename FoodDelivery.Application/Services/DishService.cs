using Microsoft.Extensions.Logging;
using FoodDelivery.Application.Repositories;
using FoodDelivery.Contracts.Dishes;
using FoodDelivery.Domain.Entities;

namespace FoodDelivery.Application.Services;

public class DishService : IDishService
{
    private readonly IRepository<Dish> _dishRepo;
    private readonly IRepository<DishCategory> _categoryRepo;
    private readonly IRepository<Restaurant> _restaurantRepo;
    private readonly ILogger<DishService> _logger;

    public DishService(
        IRepository<Dish> dishRepo,
        IRepository<DishCategory> categoryRepo,
        IRepository<Restaurant> restaurantRepo,
        ILogger<DishService> logger)
    {
        _dishRepo = dishRepo;
        _categoryRepo = categoryRepo;
        _restaurantRepo = restaurantRepo;
        _logger = logger;
    }

    public IReadOnlyList<DishDto> GetAll() =>
        _dishRepo.GetAll().Select(d => new DishDto(d.Id, d.Name, d.Weight, d.Price, d.CategoryId, d.RestaurantId)).ToList();

    public DishDto? GetById(int id)
    {
        var d = _dishRepo.GetById(id);
        return d is null ? null : new DishDto(d.Id, d.Name, d.Weight, d.Price, d.CategoryId, d.RestaurantId);
    }

    public DishDto Create(DishCreateUpdateDto dto)
    {
        var entity = new Dish
        {
            Name = dto.Name,
            Weight = dto.Weight,
            Price = dto.Price,
            CategoryId = dto.CategoryId,
            Category = _categoryRepo.GetById(dto.CategoryId),
            RestaurantId = dto.RestaurantId,
            Restaurant = _restaurantRepo.GetById(dto.RestaurantId)
        };
        var created = _dishRepo.Create(entity);
        _logger.LogInformation("Создано блюдо с Id = {Id}", created.Id);
        return new DishDto(created.Id, created.Name, created.Weight, created.Price, created.CategoryId, created.RestaurantId);
    }

    public bool Update(int id, DishCreateUpdateDto dto)
    {
        var existing = _dishRepo.GetById(id);
        if (existing is null) return false;

        existing.Name = dto.Name;
        existing.Weight = dto.Weight;
        existing.Price = dto.Price;
        existing.CategoryId = dto.CategoryId;
        existing.Category = _categoryRepo.GetById(dto.CategoryId);
        existing.RestaurantId = dto.RestaurantId;
        existing.Restaurant = _restaurantRepo.GetById(dto.RestaurantId);

        var result = _dishRepo.Update(existing);
        _logger.LogInformation("Обновлено блюдо с Id = {Id}", id);
        return result;
    }

    public void Delete(int id)
    {
        _dishRepo.Delete(id);
        _logger.LogInformation("Удалено блюдо с Id = {Id}", id);
    }
}
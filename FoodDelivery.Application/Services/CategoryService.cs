using Microsoft.Extensions.Logging;
using FoodDelivery.Application.Repositories;
using FoodDelivery.Contracts.Categories;
using FoodDelivery.Domain.Entities;

namespace FoodDelivery.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly IRepository<DishCategory> _repository;
    private readonly ILogger<CategoryService> _logger;

    public CategoryService(IRepository<DishCategory> repository, ILogger<CategoryService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public IReadOnlyList<CategoryDto> GetAll() =>
        _repository.GetAll().Select(c => new CategoryDto(c.Id, c.Name)).ToList();

    public CategoryDto? GetById(int id)
    {
        var c = _repository.GetById(id);
        return c is null ? null : new CategoryDto(c.Id, c.Name);
    }

    public CategoryDto Create(CategoryCreateUpdateDto dto)
    {
        var entity = new DishCategory
        {
            Name = dto.Name
        };
        var created = _repository.Create(entity);
        _logger.LogInformation("Создана категория с Id = {Id}", created.Id);
        return new CategoryDto(created.Id, created.Name);
    }

    public bool Update(int id, CategoryCreateUpdateDto dto)
    {
        var existing = _repository.GetById(id);
        if (existing is null) return false;

        existing.Name = dto.Name;
        var result = _repository.Update(existing);
        _logger.LogInformation("Обновлена категория с Id = {Id}", id);
        return result;
    }

    public void Delete(int id)
    {
        _repository.Delete(id);
        _logger.LogInformation("Удалена категория с Id = {Id}", id);
    }
}
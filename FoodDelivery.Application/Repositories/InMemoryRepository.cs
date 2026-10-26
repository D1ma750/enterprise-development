using FoodDelivery.Domain.Entities;

namespace FoodDelivery.Application.Repositories;

public class InMemoryRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
{
    private readonly List<TEntity> _items;

    public InMemoryRepository(List<TEntity> items)
    {
        _items = items;
    }

    public IReadOnlyList<TEntity> GetAll() => _items;

    public TEntity? GetById(int id) => _items.FirstOrDefault(x => x.Id == id);

    public TEntity Create(TEntity entity)
    {
        entity.Id = _items.Count == 0 ? 1 : _items.Max(x => x.Id) + 1;
        _items.Add(entity);
        return entity;
    }

    public bool Update(TEntity entity)
    {
        var existing = GetById(entity.Id);
        if (existing is null) return false;

        var index = _items.IndexOf(existing);
        _items[index] = entity;
        return true;
    }

    public void Delete(int id)
    {
        var existing = GetById(id);
        if (existing is not null)
        {
            _items.Remove(existing);
        }
    }
}
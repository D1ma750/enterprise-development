using FoodDelivery.Domain.Entities;

namespace FoodDelivery.Domain.Data;

/// <summary>
/// Контекст хранения коллекций сущностей в оперативной памяти.
/// </summary>
public class FoodDeliveryContext
{
    public List<Client> Clients { get; set; } = new();
    public List<Restaurant> Restaurants { get; set; } = new();
    public List<DishCategory> Categories { get; set; } = new();
    public List<Dish> Dishes { get; set; } = new();
    public List<Order> Orders { get; set; } = new();
}
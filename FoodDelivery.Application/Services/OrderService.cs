using Microsoft.Extensions.Logging;
using FoodDelivery.Application.Repositories;
using FoodDelivery.Contracts.Orders;
using FoodDelivery.Domain.Entities;

namespace FoodDelivery.Application.Services;

public class OrderService : IOrderService
{
    private readonly IRepository<Order> _orderRepo;
    private readonly IRepository<Client> _clientRepo;
    private readonly IRepository<Restaurant> _restaurantRepo;
    private readonly IRepository<Dish> _dishRepo;
    private readonly ILogger<OrderService> _logger;

    public OrderService(
        IRepository<Order> orderRepo,
        IRepository<Client> clientRepo,
        IRepository<Restaurant> restaurantRepo,
        IRepository<Dish> dishRepo,
        ILogger<OrderService> logger)
    {
        _orderRepo = orderRepo;
        _clientRepo = clientRepo;
        _restaurantRepo = restaurantRepo;
        _dishRepo = dishRepo;
        _logger = logger;
    }

    public IReadOnlyList<OrderDto> GetAll() =>
        _orderRepo.GetAll().Select(MapToDto).ToList();

    public OrderDto? GetById(int id)
    {
        var order = _orderRepo.GetById(id);
        return order is null ? null : MapToDto(order);
    }

    public OrderDto Create(OrderCreateUpdateDto dto)
    {
        var client = _clientRepo.GetById(dto.ClientId);
        var restaurant = _restaurantRepo.GetById(dto.RestaurantId);
        var dishes = _dishRepo.GetAll().Where(d => dto.DishIds.Contains(d.Id)).ToList();

        var order = new Order
        {
            ClientId = dto.ClientId,
            Client = client,
            RestaurantId = dto.RestaurantId,
            Restaurant = restaurant,
            OrderTime = dto.OrderTime,
            DeliveryTime = dto.DeliveryTime,
            TotalPrice = dto.TotalPrice,
            Dishes = dishes
        };

        var created = _orderRepo.Create(order);
        _logger.LogInformation("Создан новый заказ с Id = {Id}", created.Id);
        return MapToDto(created);
    }

    public bool Update(int id, OrderCreateUpdateDto dto)
    {
        var existing = _orderRepo.GetById(id);
        if (existing is null) return false;

        existing.ClientId = dto.ClientId;
        existing.Client = _clientRepo.GetById(dto.ClientId);
        existing.RestaurantId = dto.RestaurantId;
        existing.Restaurant = _restaurantRepo.GetById(dto.RestaurantId);
        existing.OrderTime = dto.OrderTime;
        existing.DeliveryTime = dto.DeliveryTime;
        existing.TotalPrice = dto.TotalPrice;
        existing.Dishes = _dishRepo.GetAll().Where(d => dto.DishIds.Contains(d.Id)).ToList();

        var result = _orderRepo.Update(existing);
        _logger.LogInformation("Обновлен заказ с Id = {Id}", id);
        return result;
    }

    public void Delete(int id)
    {
        _orderRepo.Delete(id);
        _logger.LogInformation("Удален заказ с Id = {Id}", id);
    }

    private static OrderDto MapToDto(Order o) =>
        new(o.Id, o.ClientId, o.RestaurantId, o.OrderTime, o.DeliveryTime, o.TotalPrice, o.Dishes.Select(d => d.Id).ToList());
}
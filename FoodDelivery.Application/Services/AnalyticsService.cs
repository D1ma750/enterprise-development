using Microsoft.Extensions.Logging;
using FoodDelivery.Application.Repositories;
using FoodDelivery.Contracts.Analytics;
using FoodDelivery.Domain.Entities;

namespace FoodDelivery.Application.Services;

public class AnalyticsService : IAnalyticsService
{
    private readonly IRepository<Order> _orderRepo;
    private readonly IRepository<Restaurant> _restaurantRepo;
    private readonly IRepository<Client> _clientRepo;
    private readonly ILogger<AnalyticsService> _logger;

    public AnalyticsService(
        IRepository<Order> orderRepo,
        IRepository<Restaurant> restaurantRepo,
        IRepository<Client> clientRepo,
        ILogger<AnalyticsService> logger)
    {
        _orderRepo = orderRepo;
        _restaurantRepo = restaurantRepo;
        _clientRepo = clientRepo;
        _logger = logger;
    }

    public IReadOnlyList<TopRestaurantDto> GetTop5Restaurants()
    {
        _logger.LogInformation("Запрос топ-5 ресторанов по количеству заказов.");
        return _orderRepo.GetAll()
            .Where(o => o.Restaurant != null)
            .GroupBy(o => o.Restaurant!)
            .Select(g => new TopRestaurantDto(g.Key.Id, g.Key.Name, g.Count()))
            .OrderByDescending(x => x.OrderCount)
            .ThenBy(x => x.Name)
            .Take(5)
            .ToList();
    }

    public IReadOnlyList<MinDeliveryOrderDto> GetOrdersWithMinDeliveryTime()
    {
        _logger.LogInformation("Запрос заказов с минимальным временем доставки.");
        var delivered = _orderRepo.GetAll().Where(o => o.DeliveryTime.HasValue).ToList();
        if (delivered.Count == 0) return [];

        var minDuration = delivered.Min(o => o.DeliveryTime!.Value - o.OrderTime);

        return delivered
            .Where(o => o.DeliveryTime!.Value - o.OrderTime == minDuration)
            .Select(o => new MinDeliveryOrderDto(
                o.Id,
                (o.DeliveryTime!.Value - o.OrderTime).TotalMinutes,
                o.OrderTime,
                o.DeliveryTime!.Value))
            .ToList();
    }

    public IReadOnlyList<ClientSummaryDto> GetClientsByRestaurant(int restaurantId)
    {
        _logger.LogInformation("Запрос клиентов ресторана {RestaurantId}.", restaurantId);
        return _orderRepo.GetAll()
            .Where(o => o.RestaurantId == restaurantId && o.Client != null)
            .Select(o => o.Client!)
            .DistinctBy(c => c.Id)
            .OrderBy(c => c.FullName)
            .Select(c => new ClientSummaryDto(c.Id, c.FullName, c.Phone, c.DeliveryAddress))
            .ToList();
    }

    public IReadOnlyList<CategorySummaryDto> GetCategorySummary(DateTime start, DateTime end)
    {
        _logger.LogInformation("Запрос сводки по категориям за период с {Start} по {End}.", start, end);
        return _orderRepo.GetAll()
            .Where(o => o.OrderTime >= start && o.OrderTime < end)
            .SelectMany(o => o.Dishes.Select(d => new { Category = d.Category!, Order = o }))
            .Where(x => x.Category != null)
            .GroupBy(x => x.Category.Id)
            .Select(g => new CategorySummaryDto(
                g.Key,
                g.First().Category.Name,
                g.Select(x => x.Order.Id).Distinct().Count(),
                g.Select(x => x.Order).DistinctBy(o => o.Id).Average(o => o.TotalPrice),
                g.Select(x => x.Order).DistinctBy(o => o.Id).Sum(o => o.TotalPrice)))
            .OrderBy(x => x.CategoryId)
            .ToList();
    }

    public IReadOnlyList<TopSpenderDto> GetTopSpenders()
    {
        _logger.LogInformation("Запрос клиентов с максимальными расходами.");
        var spendings = _orderRepo.GetAll()
            .GroupBy(o => o.ClientId)
            .Select(g => new
            {
                Client = _clientRepo.GetById(g.Key),
                Total = g.Sum(o => o.TotalPrice)
            })
            .Where(x => x.Client != null)
            .ToList();

        if (spendings.Count == 0) return [];
        var maxSpent = spendings.Max(x => x.Total);

        return spendings
            .Where(x => x.Total == maxSpent)
            .Select(x => new TopSpenderDto(x.Client!.Id, x.Client.FullName, x.Total))
            .ToList();
    }
}
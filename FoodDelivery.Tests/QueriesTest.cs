using FoodDelivery.Domain.Entities;

namespace FoodDelivery.Tests;

public class QueriesTest
{
    [Fact]
    public void Top5RestaurantsByOrderCount()
    {
        // Arrange
        var fixture = new QueriesTestFixture();

        // Act
        var result = fixture.Orders
            .GroupBy(order => order.Restaurant)
            .Select(group => new
            {
                Restaurant = group.Key!,
                OrderCount = group.Count()
            })
            .OrderByDescending(x => x.OrderCount)
            .ThenBy(x => x.Restaurant.Name)
            .Take(5)
            .ToList();

        // Assert
        Assert.Equal(5, result.Count);

        Assert.Equal("Вкусно и точка", result[0].Restaurant.Name);
        Assert.Equal(3, result[0].OrderCount);

        Assert.Equal("Ростикс", result[1].Restaurant.Name);
        Assert.Equal(3, result[1].OrderCount);

        Assert.Equal(2, result[2].OrderCount);
        Assert.Equal(2, result[3].OrderCount);
        Assert.Equal(2, result[4].OrderCount);
    }

    [Fact]
    public void OrdersWithMinimumDeliveryTime()
    {
        // Arrange
        var fixture = new QueriesTestFixture();

        // Act
        var minimumDeliveryTime = fixture.Orders
            .Min(order => order.DeliveryTime - order.OrderTime);

        var result = fixture.Orders
            .Where(order => order.DeliveryTime - order.OrderTime == minimumDeliveryTime)
            .ToList();

        // Assert
        Assert.Single(result);

        Assert.Equal(11, result[0].Id);
        Assert.Equal(TimeSpan.FromMinutes(25), minimumDeliveryTime);
    }

    [Fact]
    public void ClientsWhoOrderedFromSelectedRestaurant()
    {
        // Arrange
        var fixture = new QueriesTestFixture();
        var selectedRestaurantId = 1;

        // Act
        var result = fixture.Orders
            .Where(order => order.RestaurantId == selectedRestaurantId)
            .Select(order => order.Client!)
            .DistinctBy(client => client.Id)
            .OrderBy(client => client.FullName)
            .ToList();

        // Assert
        Assert.Equal(2, result.Count);

        Assert.Equal("Зубенко Михаил Петрович", result[0].FullName);
        Assert.Equal("Петушков Илья Викторович", result[1].FullName);
    }

    [Fact]
    public void CategorySummaryForSpecifiedPeriod()
    {
        // Arrange
        var fixture = new QueriesTestFixture();

        var startDate = new DateTime(2026, 9, 1);
        var endDate = new DateTime(2026, 9, 5);

        // Act
        var result = fixture.Orders
            .Where(order => order.OrderTime >= startDate &&
                            order.OrderTime < endDate)
            .SelectMany(order => order.Dishes
                .Select(dish => new
                {
                    Category = dish.Category!,
                    Order = order
                }))
            .GroupBy(x => x.Category.Id)
            .Select(group => new
            {
                Category = group.First().Category,
                OrderCount = group
                    .Select(x => x.Order.Id)
                    .Distinct()
                    .Count(),
                AverageOrderPrice = group
                    .Select(x => x.Order)
                    .DistinctBy(order => order.Id)
                    .Average(order => order.TotalPrice),
                TotalOrderPrice = group
                    .Select(x => x.Order)
                    .DistinctBy(order => order.Id)
                    .Sum(order => order.TotalPrice)
            })
            .OrderBy(x => x.Category.Id)
            .ToList();

        // Assert
        Assert.Equal(8, result.Count);

        var pizza = result.Single(x => x.Category.Id == 1);

        Assert.Equal("Пицца", pizza.Category.Name);
        Assert.Equal(2, pizza.OrderCount);
        Assert.Equal(760m, pizza.AverageOrderPrice);
        Assert.Equal(1520m, pizza.TotalOrderPrice);
    }

    [Fact]
    public void ClientWhoSpentTheMost()
    {
        // Arrange
        var fixture = new QueriesTestFixture();

        // Act
        var result = fixture.Orders
            .GroupBy(order => order.ClientId)
            .Select(group => new
            {
                Client = fixture.Clients.Single(client => client.Id == group.Key),
                TotalSpent = group.Sum(order => order.TotalPrice)
            })
            .OrderByDescending(x => x.TotalSpent)
            .First();

        // Assert
        Assert.Equal("Иванов Иван Иванович", result.Client.FullName);
        Assert.Equal(2990m, result.TotalSpent);
    }
}
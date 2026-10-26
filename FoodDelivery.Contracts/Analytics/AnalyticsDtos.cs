namespace FoodDelivery.Contracts.Analytics;

public record TopRestaurantDto(int RestaurantId, string Name, int OrderCount);
public record MinDeliveryOrderDto(int OrderId, double DeliveryDurationMinutes, DateTime OrderTime, DateTime DeliveryTime);
public record ClientSummaryDto(int ClientId, string FullName, string Phone, string DeliveryAddress);
public record CategorySummaryDto(int CategoryId, string CategoryName, int OrderCount, decimal AverageOrderPrice, decimal TotalOrderPrice);
public record TopSpenderDto(int ClientId, string FullName, decimal TotalSpent);
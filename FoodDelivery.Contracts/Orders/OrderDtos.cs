namespace FoodDelivery.Contracts.Orders;

public record OrderDto(
    int Id,
    int ClientId,
    int RestaurantId,
    DateTime OrderTime,
    DateTime? DeliveryTime,
    decimal TotalPrice,
    IReadOnlyList<int> DishIds);
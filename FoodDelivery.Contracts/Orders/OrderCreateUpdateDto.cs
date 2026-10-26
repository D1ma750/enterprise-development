namespace FoodDelivery.Contracts.Orders;

public record OrderCreateUpdateDto(
    int ClientId,
    int RestaurantId,
    DateTime OrderTime,
    DateTime? DeliveryTime,
    decimal TotalPrice,
    List<int> DishIds);
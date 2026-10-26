namespace FoodDelivery.Contracts.Dishes;

public record DishCreateUpdateDto(string Name, int Weight, decimal Price, int CategoryId, int RestaurantId);
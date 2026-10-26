namespace FoodDelivery.Contracts.Dishes;

public record DishDto(int Id, string Name, int Weight, decimal Price, int CategoryId, int RestaurantId);
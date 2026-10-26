namespace FoodDelivery.Contracts.Restaurants;

public record RestaurantDto(int Id, string Name, string Address, double Rating, TimeOnly OpenTime, TimeOnly CloseTime);
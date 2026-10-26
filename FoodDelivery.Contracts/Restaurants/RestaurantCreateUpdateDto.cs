namespace FoodDelivery.Contracts.Restaurants;

public record RestaurantCreateUpdateDto(string Name, string Address, double Rating, TimeOnly OpenTime, TimeOnly CloseTime);
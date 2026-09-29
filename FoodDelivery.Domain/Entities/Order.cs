namespace FoodDelivery.Domain.Entities;

/// <summary>
/// Заказ клиента.
/// </summary>
public class Order
{
    /// <summary>
    /// Идентификатор заказа.
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Идентификатор клиента.
    /// </summary>
    public required int ClientId { get; set; }

    /// <summary>
    /// Клиент, оформивший заказ.
    /// </summary>
    public Client? Client { get; set; }

    /// <summary>
    /// Идентификатор ресторана.
    /// </summary>
    public required int RestaurantId { get; set; }

    /// <summary>
    /// Ресторан, в котором оформлен заказ.
    /// </summary>
    public Restaurant? Restaurant { get; set; }

    /// <summary>
    /// Время оформления заказа.
    /// </summary>
    public required DateTime OrderTime { get; set; }

    /// <summary>
    /// Время доставки заказа.
    /// </summary>
    public required DateTime DeliveryTime { get; set; }

    /// <summary>
    /// Итоговая стоимость заказа.
    /// </summary>
    public required decimal TotalPrice { get; set; }

    /// <summary>
    /// Список блюд в заказе.
    /// </summary>
    public required List<Dish> Dishes { get; set; }
}
using Microsoft.AspNetCore.Mvc;
using FoodDelivery.Application.Services;
using FoodDelivery.Contracts.Analytics;

namespace FoodDelivery.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnalyticsController : ControllerBase
{
    private readonly IAnalyticsService _analyticsService;

    public AnalyticsController(IAnalyticsService analyticsService)
    {
        _analyticsService = analyticsService;
    }

    [HttpGet("top-restaurants")]
    [ProducesResponseType(typeof(IReadOnlyList<TopRestaurantDto>), StatusCodes.Status200OK)]
    public IActionResult GetTop5Restaurants() =>
        Ok(_analyticsService.GetTop5Restaurants());

    [HttpGet("min-delivery-orders")]
    [ProducesResponseType(typeof(IReadOnlyList<MinDeliveryOrderDto>), StatusCodes.Status200OK)]
    public IActionResult GetOrdersWithMinDeliveryTime() =>
        Ok(_analyticsService.GetOrdersWithMinDeliveryTime());

    [HttpGet("clients-by-restaurant/{restaurantId:int}")]
    [ProducesResponseType(typeof(IReadOnlyList<ClientSummaryDto>), StatusCodes.Status200OK)]
    public IActionResult GetClientsByRestaurant(int restaurantId) =>
        Ok(_analyticsService.GetClientsByRestaurant(restaurantId));

    [HttpGet("category-summary")]
    [ProducesResponseType(typeof(IReadOnlyList<CategorySummaryDto>), StatusCodes.Status200OK)]
    public IActionResult GetCategorySummary([FromQuery] DateTime start, [FromQuery] DateTime end) =>
        Ok(_analyticsService.GetCategorySummary(start, end));

    [HttpGet("top-spenders")]
    [ProducesResponseType(typeof(IReadOnlyList<TopSpenderDto>), StatusCodes.Status200OK)]
    public IActionResult GetTopSpenders() =>
        Ok(_analyticsService.GetTopSpenders());
}
using Domain.Services;

namespace Application.Services;

/// <summary>
/// Strategy Pattern
/// Service for calculating product prices using different strategies
/// </summary>
public interface IPricingService
{
    Task<decimal> CalculatePriceAsync(PricingContext context);
    Task<IEnumerable<string>> GetAvailableStrategiesAsync();
    Task<decimal> CalculatePriceWithStrategyAsync(PricingContext context, string strategyName);
}
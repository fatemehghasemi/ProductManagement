using Domain.Services;

namespace Application.Services;

/// <summary>
/// Implementation of pricing service using Strategy pattern
/// </summary>
public class PricingService : IPricingService
{
    private readonly IEnumerable<IPricingStrategy> _pricingStrategies;

    public PricingService(IEnumerable<IPricingStrategy> pricingStrategies)
    {
        _pricingStrategies = pricingStrategies;
    }

    public async Task<decimal> CalculatePriceAsync(PricingContext context)
    {
        await Task.CompletedTask;

        var strategy = _pricingStrategies.FirstOrDefault(s => s.CanHandle(context));
        
        if (strategy == null)
        {
            throw new InvalidOperationException("No pricing strategy available for the given context");
        }

        return strategy.CalculatePrice(context);
    }

    public async Task<IEnumerable<string>> GetAvailableStrategiesAsync()
    {
        await Task.CompletedTask;
        return _pricingStrategies.Select(s => s.StrategyName);
    }

    public async Task<decimal> CalculatePriceWithStrategyAsync(PricingContext context, string strategyName)
    {
        await Task.CompletedTask;

        var strategy = _pricingStrategies.FirstOrDefault(s => s.StrategyName.Equals(strategyName, StringComparison.OrdinalIgnoreCase));
        
        if (strategy == null)
        {
            throw new ArgumentException($"Pricing strategy '{strategyName}' not found");
        }

        if (!strategy.CanHandle(context))
        {
            throw new InvalidOperationException($"Strategy '{strategyName}' cannot handle the given context");
        }

        return strategy.CalculatePrice(context);
    }
}
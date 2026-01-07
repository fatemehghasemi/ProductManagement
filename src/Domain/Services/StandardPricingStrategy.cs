namespace Domain.Services;

/// <summary>
/// Standard pricing strategy for regular products
/// </summary>
public class StandardPricingStrategy : IPricingStrategy
{
    public string StrategyName => "Standard";

    public decimal CalculatePrice(PricingContext context)
    {
        if (!CanHandle(context))
            throw new InvalidOperationException($"Cannot handle pricing with {StrategyName} strategy");

        decimal basePrice = 100m; // Base price
        decimal circulationMultiplier = CalculateCirculationMultiplier(context.Circulation);
        decimal pageMultiplier = context.PageCount * 0.1m;
        decimal copyMultiplier = context.CopyCount * 0.05m;
        decimal doubleSidedMultiplier = context.IsDoubleSided ? 1.5m : 1.0m;

        return basePrice * circulationMultiplier * (1 + pageMultiplier) * (1 + copyMultiplier) * doubleSidedMultiplier;
    }

    public bool CanHandle(PricingContext context)
    {
        return context.Product != null && 
               context.Circulation > 0 && 
               context.PageCount > 0;
    }

    private static decimal CalculateCirculationMultiplier(int circulation)
    {
        return circulation switch
        {
            <= 100 => 1.0m,
            <= 500 => 0.9m,
            <= 1000 => 0.8m,
            <= 5000 => 0.7m,
            _ => 0.6m
        };
    }
}
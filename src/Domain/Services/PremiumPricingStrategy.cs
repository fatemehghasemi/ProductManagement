using Domain.Entities;

namespace Domain.Services;

/// <summary>
/// Premium pricing strategy for high-quality products
/// </summary>
public class PremiumPricingStrategy : IPricingStrategy
{
    public string StrategyName => "Premium";

    public decimal CalculatePrice(PricingContext context)
    {
        if (!CanHandle(context))
            throw new InvalidOperationException($"Cannot handle pricing with {StrategyName} strategy");

        decimal basePrice = 200m; // Higher base price for premium
        decimal qualityMultiplier = 1.5m;
        decimal circulationMultiplier = CalculateCirculationMultiplier(context.Circulation);
        decimal materialMultiplier = GetMaterialMultiplier(context.ProductMaterial);

        return basePrice * qualityMultiplier * circulationMultiplier * materialMultiplier;
    }

    public bool CanHandle(PricingContext context)
    {
        return context.Product != null && 
               context.ProductMaterial != null &&
               context.Product.IsCmyk && // Premium products use CMYK
               context.Circulation > 0;
    }

    private static decimal CalculateCirculationMultiplier(int circulation)
    {
        return circulation switch
        {
            <= 100 => 1.2m,
            <= 500 => 1.1m,
            <= 1000 => 1.0m,
            _ => 0.9m
        };
    }

    private static decimal GetMaterialMultiplier(ProductMaterial? material)
    {
        if (material?.Weight > 300) return 1.3m;
        if (material?.Weight > 200) return 1.2m;
        return 1.1m;
    }
}
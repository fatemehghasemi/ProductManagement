using Domain.Entities;

namespace Domain.Services;

/// <summary>
/// Strategy pattern for different pricing calculation methods
/// </summary>
public interface IPricingStrategy
{
    string StrategyName { get; }
    decimal CalculatePrice(PricingContext context);
    bool CanHandle(PricingContext context);
}

/// <summary>
/// Context object containing all data needed for pricing calculations
/// </summary>
public class PricingContext
{
    public Product Product { get; set; } = null!;
    public ProductSize? ProductSize { get; set; }
    public ProductMaterial? ProductMaterial { get; set; }
    public ProductPrintKind? ProductPrintKind { get; set; }
    public int Circulation { get; set; }
    public int PageCount { get; set; }
    public int CopyCount { get; set; }
    public bool IsDoubleSided { get; set; }
    public Dictionary<string, object> AdditionalParameters { get; set; } = new();
}
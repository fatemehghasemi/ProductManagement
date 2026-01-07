using MediatR;
using Domain.Common;

namespace Application.Features.Products.Commands.CalculateProductPrice;

public record CalculateProductPriceCommand(
    int ProductId,
    int? ProductSizeId = null,
    int? ProductMaterialId = null,
    int? ProductPrintKindId = null,
    int Circulation = 1000,
    int PageCount = 1,
    int CopyCount = 1,
    bool IsDoubleSided = false,
    string? PreferredStrategy = null
) : IRequest<Result<CalculateProductPriceResponse>>;

public class CalculateProductPriceResponse
{
    public decimal CalculatedPrice { get; set; }
    public string UsedStrategy { get; set; } = string.Empty;
    public Dictionary<string, object> PricingDetails { get; set; } = new();
}
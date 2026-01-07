using MediatR;
using Domain.Common;
using Domain.Interfaces;
using Domain.Services;
using Application.Services;

namespace Application.Features.Products.Commands.CalculateProductPrice;

/// <summary>
/// Factory Pattern
/// </summary>
public class CalculateProductPriceHandler : IRequestHandler<CalculateProductPriceCommand, Result<CalculateProductPriceResponse>>
{
    private readonly IProductRepository _productRepository;
    private readonly IProductSizeRepository _productSizeRepository;
    private readonly IProductMaterialRepository _productMaterialRepository;
    private readonly IProductPrintKindRepository _productPrintKindRepository;
    private readonly IPricingService _pricingService;

    public CalculateProductPriceHandler(
        IProductRepository productRepository,
        IProductSizeRepository productSizeRepository,
        IProductMaterialRepository productMaterialRepository,
        IProductPrintKindRepository productPrintKindRepository,
        IPricingService pricingService)
    {
        _productRepository = productRepository;
        _productSizeRepository = productSizeRepository;
        _productMaterialRepository = productMaterialRepository;
        _productPrintKindRepository = productPrintKindRepository;
        _pricingService = pricingService;
    }

    public async Task<Result<CalculateProductPriceResponse>> Handle(CalculateProductPriceCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var product = await _productRepository.GetByIdAsync(request.ProductId, cancellationToken);
            if (product == null)
            {
                return Result<CalculateProductPriceResponse>.Fail("Product not found", 404);
            }

            var context = new PricingContext
            {
                Product = product,
                Circulation = request.Circulation,
                PageCount = request.PageCount,
                CopyCount = request.CopyCount,
                IsDoubleSided = request.IsDoubleSided
            };

            if (request.ProductSizeId.HasValue)
            {
                context.ProductSize = await _productSizeRepository.GetByIdAsync(request.ProductSizeId.Value, cancellationToken);
            }

            if (request.ProductMaterialId.HasValue)
            {
                context.ProductMaterial = await _productMaterialRepository.GetByIdAsync(request.ProductMaterialId.Value, cancellationToken);
            }

            if (request.ProductPrintKindId.HasValue)
            {
                context.ProductPrintKind = await _productPrintKindRepository.GetByIdAsync(request.ProductPrintKindId.Value, cancellationToken);
            }

            // Calculate price using strategy pattern
            decimal calculatedPrice;
            string usedStrategy;

            if (!string.IsNullOrEmpty(request.PreferredStrategy))
            {
                calculatedPrice = await _pricingService.CalculatePriceWithStrategyAsync(context, request.PreferredStrategy);
                usedStrategy = request.PreferredStrategy;
            }
            else
            {
                calculatedPrice = await _pricingService.CalculatePriceAsync(context);
                var availableStrategies = await _pricingService.GetAvailableStrategiesAsync();
                usedStrategy = availableStrategies.First(); 
            }

            var response = new CalculateProductPriceResponse
            {
                CalculatedPrice = calculatedPrice,
                UsedStrategy = usedStrategy,
                PricingDetails = new Dictionary<string, object>
                {
                    ["ProductId"] = request.ProductId,
                    ["Circulation"] = request.Circulation,
                    ["PageCount"] = request.PageCount,
                    ["CopyCount"] = request.CopyCount,
                    ["IsDoubleSided"] = request.IsDoubleSided,
                    ["HasSize"] = context.ProductSize != null,
                    ["HasMaterial"] = context.ProductMaterial != null,
                    ["HasPrintKind"] = context.ProductPrintKind != null
                }
            };

            return Result<CalculateProductPriceResponse>.Success(response);
        }
        catch (ArgumentException ex)
        {
            return Result<CalculateProductPriceResponse>.Fail(ex.Message, 400);
        }
        catch (InvalidOperationException ex)
        {
            return Result<CalculateProductPriceResponse>.Fail(ex.Message, 400);
        }
        catch (Exception ex)
        {
            return Result<CalculateProductPriceResponse>.Fail($"An error occurred while calculating price: {ex.Message}", 500);
        }
    }
}
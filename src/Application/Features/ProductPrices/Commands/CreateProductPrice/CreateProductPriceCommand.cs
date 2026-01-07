using MediatR;
using Application.Features.ProductPrices.Responses;
using Domain.Common;

namespace Application.Features.ProductPrices.Commands.CreateProductPrice;

public record CreateProductPriceCommand(
    float Price,
    int Circulation,
    bool IsDoubleSided,
    int? PageCount,
    int? CopyCount,
    int ProductSizeId,
    int ProductMaterialId,
    int? ProductMaterialAttributeId,
    int ProductPrintKindId,
    bool IsJeld
) : IRequest<Result<CreateProductPriceResponse>>;
using MediatR;
using Application.Features.ProductSizes.Responses;
using Domain.Common;

namespace Application.Features.ProductSizes.Commands.UpdateProductSize;

public record UpdateProductSizeCommand(
    int Id,
    int ProductId,
    float Length,
    float Width,
    string Name,
    int? SheetCount,
    int SheetDimensionId
) : IRequest<Result<UpdateProductSizeResponse>>;
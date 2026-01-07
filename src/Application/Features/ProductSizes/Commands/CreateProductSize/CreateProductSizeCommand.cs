using MediatR;
using Application.Features.ProductSizes.Responses;
using Domain.Common;

namespace Application.Features.ProductSizes.Commands.CreateProductSize;

public record CreateProductSizeCommand(
    int ProductId,
    float Length,
    float Width,
    string Name,
    int? SheetCount,
    int SheetDimensionId
) : IRequest<Result<CreateProductSizeResponse>>;
using MediatR;
using Application.Features.ProductAdtPrices.Responses;
using Domain.Common;

namespace Application.Features.ProductAdtPrices.Commands.CreateProductAdtPrice;

public record CreateProductAdtPriceCommand(
    int ProductAdtId,
    int ProductPriceId,
    int ProductAdtTypeId,
    float Price
) : IRequest<Result<CreateProductAdtPriceResponse>>;
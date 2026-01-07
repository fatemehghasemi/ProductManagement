using MediatR;
using Application.Features.ProductPrices.Responses;
using Domain.Common;

namespace Application.Features.ProductPrices.Commands.UpdateProductPrice;

public record UpdateProductPriceCommand(
    int Id,
    int ProductId,
    int CirculationFrom,
    int CirculationTo,
    float Price
) : IRequest<Result<UpdateProductPriceResponse>>;
using MediatR;
using Application.Features.ProductDeliverSizes.Responses;
using Domain.Common;

namespace Application.Features.ProductDeliverSizes.Commands.CreateProductDeliverSize;

public record CreateProductDeliverSizeCommand(
    int ProductSizeId,
    int ProductDeliverId
) : IRequest<Result<CreateProductDeliverSizeResponse>>;
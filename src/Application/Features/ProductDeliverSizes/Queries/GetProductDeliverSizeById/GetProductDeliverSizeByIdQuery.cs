using MediatR;
using Application.Features.ProductDeliverSizes.Responses;
using Domain.Common;

namespace Application.Features.ProductDeliverSizes.Queries.GetProductDeliverSizeById;

public record GetProductDeliverSizeByIdQuery(int Id) : IRequest<Result<GetProductDeliverSizeByIdResponse>>;
using MediatR;
using Application.Features.ProductDeliverSizes.Responses;
using Domain.Common;

namespace Application.Features.ProductDeliverSizes.Queries.GetAllProductDeliverSizes;

public record GetAllProductDeliverSizesQuery(int? ProductDeliverId = null, int? ProductSizeId = null) : IRequest<Result<IEnumerable<GetAllProductDeliverSizesResponse>>>;
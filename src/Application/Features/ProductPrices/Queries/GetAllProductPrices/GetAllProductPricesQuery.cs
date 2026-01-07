using MediatR;
using Application.Features.ProductPrices.Responses;
using Domain.Common;

namespace Application.Features.ProductPrices.Queries.GetAllProductPrices;

public record GetAllProductPricesQuery(int? ProductSizeId) : IRequest<Result<IEnumerable<GetAllProductPricesResponse>>>;
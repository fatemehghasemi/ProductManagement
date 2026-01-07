using MediatR;
using Application.Features.ProductAdtPrices.Responses;
using Domain.Common;

namespace Application.Features.ProductAdtPrices.Queries.GetAllProductAdtPrices;

public record GetAllProductAdtPricesQuery(int? ProductAdtId = null) : IRequest<Result<IEnumerable<GetAllProductAdtPricesResponse>>>;
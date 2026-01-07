using MediatR;
using Application.Features.ProductSizes.Responses;
using Domain.Common;

namespace Application.Features.ProductSizes.Queries.GetAllProductSizes;

public record GetAllProductSizesQuery(int? ProductId) : IRequest<Result<IEnumerable<GetAllProductSizesResponse>>>;
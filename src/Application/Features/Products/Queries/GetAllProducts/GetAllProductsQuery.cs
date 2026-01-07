using MediatR;
using Application.Features.Products.Responses;
using Domain.Common;

namespace Application.Features.Products.Queries.GetAllProducts;

public record GetAllProductsQuery(int? ProductGroupId) : IRequest<Result<IEnumerable<GetAllProductsResponse>>>;
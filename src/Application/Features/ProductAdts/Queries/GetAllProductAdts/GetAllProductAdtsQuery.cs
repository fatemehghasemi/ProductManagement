using MediatR;
using Application.Features.ProductAdts.Responses;
using Domain.Common;

namespace Application.Features.ProductAdts.Queries.GetAllProductAdts;

public record GetAllProductAdtsQuery(int? ProductId) : IRequest<Result<IEnumerable<GetAllProductAdtsResponse>>>;
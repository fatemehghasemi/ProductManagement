using MediatR;
using Application.Features.ProductDelivers.Responses;
using Domain.Common;

namespace Application.Features.ProductDelivers.Queries.GetAllProductDelivers;

public record GetAllProductDeliversQuery(int? ProductId) : IRequest<Result<IEnumerable<GetAllProductDeliversResponse>>>;
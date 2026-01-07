using MediatR;
using Application.Features.ProductDelivers.Responses;
using Domain.Common;

namespace Application.Features.ProductDelivers.Queries.GetProductDeliverById;

public record GetProductDeliverByIdQuery(int Id) : IRequest<Result<GetProductDeliverByIdResponse>>;
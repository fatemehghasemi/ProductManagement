using MediatR;
using Application.Features.ProductAdts.Responses;
using Domain.Common;

namespace Application.Features.ProductAdts.Queries.GetProductAdtById;

public record GetProductAdtByIdQuery(int Id) : IRequest<Result<GetProductAdtByIdResponse>>;
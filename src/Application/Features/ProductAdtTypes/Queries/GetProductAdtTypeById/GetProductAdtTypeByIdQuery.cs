using MediatR;
using Application.Features.ProductAdtTypes.Responses;
using Domain.Common;

namespace Application.Features.ProductAdtTypes.Queries.GetProductAdtTypeById;

public record GetProductAdtTypeByIdQuery(int Id) : IRequest<Result<GetProductAdtTypeByIdResponse>>;
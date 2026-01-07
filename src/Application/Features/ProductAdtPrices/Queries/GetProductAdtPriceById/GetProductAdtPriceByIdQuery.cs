using MediatR;
using Application.Features.ProductAdtPrices.Responses;
using Domain.Common;

namespace Application.Features.ProductAdtPrices.Queries.GetProductAdtPriceById;

public record GetProductAdtPriceByIdQuery(int Id) : IRequest<Result<GetProductAdtPriceByIdResponse>>;
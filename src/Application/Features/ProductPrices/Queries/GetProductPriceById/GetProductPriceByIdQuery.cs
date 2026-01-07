using MediatR;
using Application.Features.ProductPrices.Responses;
using Domain.Common;

namespace Application.Features.ProductPrices.Queries.GetProductPriceById;

public record GetProductPriceByIdQuery(int Id) : IRequest<Result<GetProductPriceByIdResponse>>;
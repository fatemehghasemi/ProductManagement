using MediatR;
using Application.Features.ProductSizes.Responses;
using Domain.Common;

namespace Application.Features.ProductSizes.Queries.GetProductSizeById;

public record GetProductSizeByIdQuery(int Id) : IRequest<Result<GetProductSizeByIdResponse>>;
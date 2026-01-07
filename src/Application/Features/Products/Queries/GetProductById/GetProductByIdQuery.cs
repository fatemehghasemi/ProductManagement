using MediatR;
using Application.Features.Products.Responses;
using Domain.Common;

namespace Application.Features.Products.Queries.GetProductById;

public record GetProductByIdQuery(int Id) : IRequest<Result<GetProductByIdResponse>>;
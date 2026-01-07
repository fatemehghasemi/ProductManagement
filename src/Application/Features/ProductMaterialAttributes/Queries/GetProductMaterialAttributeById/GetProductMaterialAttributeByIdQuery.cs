using MediatR;
using Application.Features.ProductMaterialAttributes.Responses;
using Domain.Common;

namespace Application.Features.ProductMaterialAttributes.Queries.GetProductMaterialAttributeById;

public record GetProductMaterialAttributeByIdQuery(int Id) : IRequest<Result<GetProductMaterialAttributeByIdResponse>>;
using MediatR;
using Application.Features.ProductMaterials.Responses;
using Domain.Common;

namespace Application.Features.ProductMaterials.Queries.GetProductMaterialById;

public record GetProductMaterialByIdQuery(int Id) : IRequest<Result<GetProductMaterialByIdResponse>>;
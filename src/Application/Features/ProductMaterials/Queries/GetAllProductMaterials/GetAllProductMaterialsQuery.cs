using MediatR;
using Application.Features.ProductMaterials.Responses;
using Domain.Common;

namespace Application.Features.ProductMaterials.Queries.GetAllProductMaterials;

public record GetAllProductMaterialsQuery(int? ProductId) : IRequest<Result<IEnumerable<GetAllProductMaterialsResponse>>>;
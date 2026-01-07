using MediatR;
using Application.Features.ProductMaterialAttributes.Responses;
using Domain.Common;

namespace Application.Features.ProductMaterialAttributes.Queries.GetAllProductMaterialAttributes;

public record GetAllProductMaterialAttributesQuery(int? ProductMaterialId = null) : IRequest<Result<IEnumerable<GetAllProductMaterialAttributesResponse>>>;
using MediatR;
using Application.Features.ProductMaterials.Responses;
using Domain.Common;

namespace Application.Features.ProductMaterials.Commands.UpdateProductMaterial;

public record UpdateProductMaterialCommand(
    int Id,
    int ProductId,
    int MaterialId,
    string Name,
    bool IsJeld,
    bool Required,
    bool IsCustomCirculation,
    bool IsCombinedMaterial,
    int? Weight
) : IRequest<Result<UpdateProductMaterialResponse>>;
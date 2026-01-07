using MediatR;
using Application.Features.ProductMaterials.Responses;
using Domain.Common;

namespace Application.Features.ProductMaterials.Commands.CreateProductMaterial;

public record CreateProductMaterialCommand(
    int ProductId,
    int MaterialId,
    string Name,
    bool IsJeld,
    bool Required,
    bool IsCustomCirculation,
    bool IsCombinedMaterial,
    int? Weight
) : IRequest<Result<CreateProductMaterialResponse>>;
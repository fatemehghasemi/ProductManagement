using Mapster;
using MediatR;
using Domain.Interfaces;
using Application.Features.ProductMaterials.Responses;
using Domain.Common;

namespace Application.Features.ProductMaterials.Commands.UpdateProductMaterial;

public sealed class UpdateProductMaterialHandler : IRequestHandler<UpdateProductMaterialCommand, Result<UpdateProductMaterialResponse>>
{
    private readonly IProductMaterialRepository _productMaterialRepository;

    public UpdateProductMaterialHandler(IProductMaterialRepository productMaterialRepository)
    {
        _productMaterialRepository = productMaterialRepository;
    }

    public async Task<Result<UpdateProductMaterialResponse>> Handle(UpdateProductMaterialCommand request, CancellationToken cancellationToken)
    {
        var existingProductMaterial = await _productMaterialRepository.GetByIdAsync(request.Id, cancellationToken);
        if (existingProductMaterial == null)
        {
            return Result<UpdateProductMaterialResponse>.Fail("Product material not found", 404);
        }

        request.Adapt(existingProductMaterial);

        var updatedProductMaterial = await _productMaterialRepository.UpdateAsync(existingProductMaterial, cancellationToken);
        var response = updatedProductMaterial.Adapt<UpdateProductMaterialResponse>();

        return Result<UpdateProductMaterialResponse>.Success(response);
    }
}
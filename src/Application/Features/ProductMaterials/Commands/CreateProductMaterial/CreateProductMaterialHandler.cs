using Mapster;
using MediatR;
using Domain.Interfaces;
using Application.Features.ProductMaterials.Responses;
using Domain.Common;

namespace Application.Features.ProductMaterials.Commands.CreateProductMaterial;

public sealed class CreateProductMaterialHandler : IRequestHandler<CreateProductMaterialCommand, Result<CreateProductMaterialResponse>>
{
    private readonly IProductMaterialRepository _productMaterialRepository;

    public CreateProductMaterialHandler(IProductMaterialRepository productMaterialRepository)
    {
        _productMaterialRepository = productMaterialRepository;
    }

    public async Task<Result<CreateProductMaterialResponse>> Handle(CreateProductMaterialCommand request, CancellationToken cancellationToken)
    {
        var productMaterial = request.Adapt<Domain.Entities.ProductMaterial>();

        var createdProductMaterial = await _productMaterialRepository.AddAsync(productMaterial);
        var response = createdProductMaterial.Adapt<CreateProductMaterialResponse>();

        return Result<CreateProductMaterialResponse>.Success(response);
    }
}
using Mapster;
using MediatR;
using Domain.Interfaces;
using Application.Features.ProductMaterials.Responses;
using Domain.Common;

namespace Application.Features.ProductMaterials.Queries.GetProductMaterialById;

public sealed class GetProductMaterialByIdHandler : IRequestHandler<GetProductMaterialByIdQuery, Result<GetProductMaterialByIdResponse>>
{
    private readonly IProductMaterialRepository _productMaterialRepository;

    public GetProductMaterialByIdHandler(IProductMaterialRepository productMaterialRepository)
    {
        _productMaterialRepository = productMaterialRepository;
    }

    public async Task<Result<GetProductMaterialByIdResponse>> Handle(GetProductMaterialByIdQuery request, CancellationToken cancellationToken)
    {
        var productMaterial = await _productMaterialRepository.GetByIdAsync(request.Id, cancellationToken);
        if (productMaterial == null)
        {
            return Result<GetProductMaterialByIdResponse>.Fail("Product material not found", 404);
        }

        var response = productMaterial.Adapt<GetProductMaterialByIdResponse>();
        return Result<GetProductMaterialByIdResponse>.Success(response);
    }
}
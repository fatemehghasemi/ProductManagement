using Mapster;
using MediatR;
using Domain.Interfaces;
using Domain.Entities;
using Application.Features.ProductMaterials.Responses;
using Domain.Common;

namespace Application.Features.ProductMaterials.Queries.GetAllProductMaterials;

public sealed class GetAllProductMaterialsHandler : IRequestHandler<GetAllProductMaterialsQuery, Result<IEnumerable<GetAllProductMaterialsResponse>>>
{
    private readonly IProductMaterialRepository _productMaterialRepository;

    public GetAllProductMaterialsHandler(IProductMaterialRepository productMaterialRepository)
    {
        _productMaterialRepository = productMaterialRepository;
    }

    public async Task<Result<IEnumerable<GetAllProductMaterialsResponse>>> Handle(GetAllProductMaterialsQuery request, CancellationToken cancellationToken)
    {
        var productMaterials = await _productMaterialRepository.GetAllAsync(cancellationToken);
        
        IEnumerable<ProductMaterial> filteredProductMaterials = productMaterials;
        if (request.ProductId.HasValue)
        {
            filteredProductMaterials = productMaterials.Where(pm => pm.ProductId == request.ProductId.Value);
        }

        var response = filteredProductMaterials.Adapt<IEnumerable<GetAllProductMaterialsResponse>>();
        return Result<IEnumerable<GetAllProductMaterialsResponse>>.Success(response);
    }
}
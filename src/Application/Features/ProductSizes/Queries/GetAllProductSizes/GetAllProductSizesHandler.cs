using Mapster;
using MediatR;
using Domain.Interfaces;
using Domain.Entities;
using Application.Features.ProductSizes.Responses;
using Domain.Common;

namespace Application.Features.ProductSizes.Queries.GetAllProductSizes;

public sealed class GetAllProductSizesHandler : IRequestHandler<GetAllProductSizesQuery, Result<IEnumerable<GetAllProductSizesResponse>>>
{
    private readonly IProductSizeRepository _productSizeRepository;

    public GetAllProductSizesHandler(IProductSizeRepository productSizeRepository)
    {
        _productSizeRepository = productSizeRepository;
    }

    public async Task<Result<IEnumerable<GetAllProductSizesResponse>>> Handle(GetAllProductSizesQuery request, CancellationToken cancellationToken)
    {
        var productSizes = await _productSizeRepository.GetAllAsync(cancellationToken);
        
        IEnumerable<ProductSize> filteredProductSizes = productSizes;
        if (request.ProductId.HasValue)
        {
            filteredProductSizes = productSizes.Where(ps => ps.ProductId == request.ProductId.Value);
        }

        var response = filteredProductSizes.Adapt<IEnumerable<GetAllProductSizesResponse>>();
        return Result<IEnumerable<GetAllProductSizesResponse>>.Success(response);
    }
}
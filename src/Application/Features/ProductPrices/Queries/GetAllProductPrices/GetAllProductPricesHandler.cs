using Mapster;
using MediatR;
using Domain.Interfaces;
using Domain.Entities;
using Application.Features.ProductPrices.Responses;
using Domain.Common;

namespace Application.Features.ProductPrices.Queries.GetAllProductPrices;

public sealed class GetAllProductPricesHandler : IRequestHandler<GetAllProductPricesQuery, Result<IEnumerable<GetAllProductPricesResponse>>>
{
    private readonly IProductPriceRepository _productPriceRepository;

    public GetAllProductPricesHandler(IProductPriceRepository productPriceRepository)
    {
        _productPriceRepository = productPriceRepository;
    }

    public async Task<Result<IEnumerable<GetAllProductPricesResponse>>> Handle(GetAllProductPricesQuery request, CancellationToken cancellationToken)
    {
        var productPrices = await _productPriceRepository.GetAllAsync();
        
        IEnumerable<ProductPrice> filteredProductPrices = productPrices;
        if (request.ProductSizeId.HasValue)
        {
            filteredProductPrices = productPrices.Where(pp => pp.ProductSizeId == request.ProductSizeId.Value);
        }

        var response = filteredProductPrices.Adapt<IEnumerable<GetAllProductPricesResponse>>();
        return Result<IEnumerable<GetAllProductPricesResponse>>.Success(response);
    }
}
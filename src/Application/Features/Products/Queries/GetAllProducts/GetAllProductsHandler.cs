using Mapster;
using MediatR;
using Domain.Interfaces;
using Domain.Entities;
using Application.Features.Products.Responses;
using Domain.Common;

namespace Application.Features.Products.Queries.GetAllProducts;

public sealed class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, Result<IEnumerable<GetAllProductsResponse>>>
{
    private readonly IProductRepository _productRepository;

    public GetAllProductsHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Result<IEnumerable<GetAllProductsResponse>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetAllAsync();
        
        IEnumerable<Product> filteredProducts = products;
        if (request.ProductGroupId.HasValue)
        {
            filteredProducts = products.Where(p => p.ProductGroupId == request.ProductGroupId.Value);
        }

        var response = filteredProducts.Adapt<IEnumerable<GetAllProductsResponse>>();
        return Result<IEnumerable<GetAllProductsResponse>>.Success(response);
    }
}
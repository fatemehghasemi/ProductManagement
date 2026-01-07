using Mapster;
using MediatR;
using Domain.Interfaces;
using Application.Features.Products.Responses;
using Domain.Common;

namespace Application.Features.Products.Queries.GetProductById;

public sealed class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Result<GetProductByIdResponse>>
{
    private readonly IProductRepository _productRepository;

    public GetProductByIdHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Result<GetProductByIdResponse>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id);
        if (product == null)
        {
            return Result<GetProductByIdResponse>.Fail("Product not found", 404);
        }

        var response = product.Adapt<GetProductByIdResponse>();
        return Result<GetProductByIdResponse>.Success(response);
    }
}
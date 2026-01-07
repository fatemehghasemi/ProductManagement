using Mapster;
using MediatR;
using Domain.Interfaces;
using Application.Features.Products.Responses;
using Domain.Common;

namespace Application.Features.Products.Commands.UpdateProduct;

public sealed class UpdateProductHandler : IRequestHandler<UpdateProductCommand, Result<UpdateProductResponse>>
{
    private readonly IProductRepository _productRepository;

    public UpdateProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Result<UpdateProductResponse>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var existingProduct = await _productRepository.GetByIdAsync(request.Id);
        if (existingProduct == null)
        {
            return Result<UpdateProductResponse>.Fail("Product not found", 404);
        }

        request.Adapt(existingProduct);

        var updatedProduct = await _productRepository.UpdateAsync(existingProduct);
        var response = updatedProduct.Adapt<UpdateProductResponse>();

        return Result<UpdateProductResponse>.Success(response);
    }
}
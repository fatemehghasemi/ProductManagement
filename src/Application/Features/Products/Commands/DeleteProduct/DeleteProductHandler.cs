using MediatR;
using Domain.Interfaces;
using Domain.Common;

namespace Application.Features.Products.Commands.DeleteProduct;

public sealed class DeleteProductHandler : IRequestHandler<DeleteProductCommand, Result<bool>>
{
    private readonly IProductRepository _productRepository;

    public DeleteProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Result<bool>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var exists = await _productRepository.ExistsAsync(request.Id);
        if (!exists)
        {
            return Result<bool>.Fail("Product not found", 404);
        }

        var deleted = await _productRepository.DeleteAsync(request.Id);
        return Result<bool>.Success(deleted);
    }
}
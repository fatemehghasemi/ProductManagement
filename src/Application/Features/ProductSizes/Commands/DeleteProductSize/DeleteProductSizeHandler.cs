using MediatR;
using Domain.Interfaces;
using Domain.Common;

namespace Application.Features.ProductSizes.Commands.DeleteProductSize;

public sealed class DeleteProductSizeHandler : IRequestHandler<DeleteProductSizeCommand, Result<bool>>
{
    private readonly IProductSizeRepository _productSizeRepository;

    public DeleteProductSizeHandler(IProductSizeRepository productSizeRepository)
    {
        _productSizeRepository = productSizeRepository;
    }

    public async Task<Result<bool>> Handle(DeleteProductSizeCommand request, CancellationToken cancellationToken)
    {
        var exists = await _productSizeRepository.ExistsAsync(request.Id, cancellationToken);
        if (!exists)
        {
            return Result<bool>.Fail("Product size not found", 404);
        }

        var deleted = await _productSizeRepository.DeleteAsync(request.Id, cancellationToken);
        return Result<bool>.Success(deleted);
    }
}
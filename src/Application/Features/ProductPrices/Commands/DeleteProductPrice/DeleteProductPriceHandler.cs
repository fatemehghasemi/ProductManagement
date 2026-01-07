using MediatR;
using Domain.Interfaces;
using Domain.Common;

namespace Application.Features.ProductPrices.Commands.DeleteProductPrice;

public sealed class DeleteProductPriceHandler : IRequestHandler<DeleteProductPriceCommand, Result<bool>>
{
    private readonly IProductPriceRepository _productPriceRepository;

    public DeleteProductPriceHandler(IProductPriceRepository productPriceRepository)
    {
        _productPriceRepository = productPriceRepository;
    }

    public async Task<Result<bool>> Handle(DeleteProductPriceCommand request, CancellationToken cancellationToken)
    {
        var exists = await _productPriceRepository.ExistsAsync(request.Id);
        if (!exists)
        {
            return Result<bool>.Fail("Product price not found", 404);
        }

        var deleted = await _productPriceRepository.DeleteAsync(request.Id);
        return Result<bool>.Success(deleted);
    }
}
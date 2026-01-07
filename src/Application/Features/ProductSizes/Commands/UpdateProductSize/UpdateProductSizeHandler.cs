using Mapster;
using MediatR;
using Domain.Interfaces;
using Application.Features.ProductSizes.Responses;
using Domain.Common;

namespace Application.Features.ProductSizes.Commands.UpdateProductSize;

public sealed class UpdateProductSizeHandler : IRequestHandler<UpdateProductSizeCommand, Result<UpdateProductSizeResponse>>
{
    private readonly IProductSizeRepository _productSizeRepository;

    public UpdateProductSizeHandler(IProductSizeRepository productSizeRepository)
    {
        _productSizeRepository = productSizeRepository;
    }

    public async Task<Result<UpdateProductSizeResponse>> Handle(UpdateProductSizeCommand request, CancellationToken cancellationToken)
    {
        var existingProductSize = await _productSizeRepository.GetByIdAsync(request.Id, cancellationToken);
        if (existingProductSize == null)
        {
            return Result<UpdateProductSizeResponse>.Fail("Product size not found", 404);
        }

        request.Adapt(existingProductSize);

        var updatedProductSize = await _productSizeRepository.UpdateAsync(existingProductSize, cancellationToken);
        var response = updatedProductSize.Adapt<UpdateProductSizeResponse>();

        return Result<UpdateProductSizeResponse>.Success(response);
    }
}
using Mapster;
using MediatR;
using Domain.Interfaces;
using Application.Features.ProductPrices.Responses;
using Domain.Common;

namespace Application.Features.ProductPrices.Commands.UpdateProductPrice;

public sealed class UpdateProductPriceHandler : IRequestHandler<UpdateProductPriceCommand, Result<UpdateProductPriceResponse>>
{
    private readonly IProductPriceRepository _productPriceRepository;

    public UpdateProductPriceHandler(IProductPriceRepository productPriceRepository)
    {
        _productPriceRepository = productPriceRepository;
    }

    public async Task<Result<UpdateProductPriceResponse>> Handle(UpdateProductPriceCommand request, CancellationToken cancellationToken)
    {
        var existingProductPrice = await _productPriceRepository.GetByIdAsync(request.Id);
        if (existingProductPrice == null)
        {
            return Result<UpdateProductPriceResponse>.Fail("Product price not found", 404);
        }

        request.Adapt(existingProductPrice);

        var updatedProductPrice = await _productPriceRepository.UpdateAsync(existingProductPrice);
        var response = updatedProductPrice.Adapt<UpdateProductPriceResponse>();

        return Result<UpdateProductPriceResponse>.Success(response);
    }
}
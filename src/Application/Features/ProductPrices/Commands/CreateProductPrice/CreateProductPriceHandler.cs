using Mapster;
using MediatR;
using Domain.Interfaces;
using Application.Features.ProductPrices.Responses;
using Domain.Common;

namespace Application.Features.ProductPrices.Commands.CreateProductPrice;

public sealed class CreateProductPriceHandler : IRequestHandler<CreateProductPriceCommand, Result<CreateProductPriceResponse>>
{
    private readonly IProductPriceRepository _productPriceRepository;

    public CreateProductPriceHandler(IProductPriceRepository productPriceRepository)
    {
        _productPriceRepository = productPriceRepository;
    }

    public async Task<Result<CreateProductPriceResponse>> Handle(CreateProductPriceCommand request, CancellationToken cancellationToken)
    {
        var productPrice = request.Adapt<Domain.Entities.ProductPrice>();

        var createdProductPrice = await _productPriceRepository.AddAsync(productPrice);
        var response = createdProductPrice.Adapt<CreateProductPriceResponse>();

        return Result<CreateProductPriceResponse>.Success(response);
    }
}
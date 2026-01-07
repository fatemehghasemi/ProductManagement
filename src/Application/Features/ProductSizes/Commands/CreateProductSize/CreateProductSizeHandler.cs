using Mapster;
using MediatR;
using Domain.Interfaces;
using Application.Features.ProductSizes.Responses;
using Domain.Common;

namespace Application.Features.ProductSizes.Commands.CreateProductSize;

public sealed class CreateProductSizeHandler : IRequestHandler<CreateProductSizeCommand, Result<CreateProductSizeResponse>>
{
    private readonly IProductSizeRepository _productSizeRepository;

    public CreateProductSizeHandler(IProductSizeRepository productSizeRepository)
    {
        _productSizeRepository = productSizeRepository;
    }

    public async Task<Result<CreateProductSizeResponse>> Handle(CreateProductSizeCommand request, CancellationToken cancellationToken)
    {
        var productSize = request.Adapt<Domain.Entities.ProductSize>();

        var createdProductSize = await _productSizeRepository.AddAsync(productSize);
        var response = createdProductSize.Adapt<CreateProductSizeResponse>();

        return Result<CreateProductSizeResponse>.Success(response);
    }
}
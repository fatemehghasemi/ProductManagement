using Mapster;
using MediatR;
using Domain.Interfaces;
using Application.Features.ProductPrices.Responses;
using Domain.Common;

namespace Application.Features.ProductPrices.Queries.GetProductPriceById;

public sealed class GetProductPriceByIdHandler : IRequestHandler<GetProductPriceByIdQuery, Result<GetProductPriceByIdResponse>>
{
    private readonly IProductPriceRepository _productPriceRepository;

    public GetProductPriceByIdHandler(IProductPriceRepository productPriceRepository)
    {
        _productPriceRepository = productPriceRepository;
    }

    public async Task<Result<GetProductPriceByIdResponse>> Handle(GetProductPriceByIdQuery request, CancellationToken cancellationToken)
    {
        var productPrice = await _productPriceRepository.GetByIdAsync(request.Id);
        if (productPrice == null)
        {
            return Result<GetProductPriceByIdResponse>.Fail("Product price not found", 404);
        }

        var response = productPrice.Adapt<GetProductPriceByIdResponse>();
        return Result<GetProductPriceByIdResponse>.Success(response);
    }
}
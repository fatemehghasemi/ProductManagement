using Mapster;
using MediatR;
using Domain.Interfaces;
using Application.Features.ProductSizes.Responses;
using Domain.Common;

namespace Application.Features.ProductSizes.Queries.GetProductSizeById;

public sealed class GetProductSizeByIdHandler : IRequestHandler<GetProductSizeByIdQuery, Result<GetProductSizeByIdResponse>>
{
    private readonly IProductSizeRepository _productSizeRepository;

    public GetProductSizeByIdHandler(IProductSizeRepository productSizeRepository)
    {
        _productSizeRepository = productSizeRepository;
    }

    public async Task<Result<GetProductSizeByIdResponse>> Handle(GetProductSizeByIdQuery request, CancellationToken cancellationToken)
    {
        var productSize = await _productSizeRepository.GetByIdAsync(request.Id, cancellationToken);
        if (productSize == null)
        {
            return Result<GetProductSizeByIdResponse>.Fail("Product size not found", 404);
        }

        var response = productSize.Adapt<GetProductSizeByIdResponse>();
        return Result<GetProductSizeByIdResponse>.Success(response);
    }
}
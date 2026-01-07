using MediatR;
using Domain.Common;
using Domain.Interfaces;
using Application.Features.ProductDeliverSizes.Responses;

namespace Application.Features.ProductDeliverSizes.Queries.GetProductDeliverSizeById;

public class GetProductDeliverSizeByIdHandler : IRequestHandler<GetProductDeliverSizeByIdQuery, Result<GetProductDeliverSizeByIdResponse>>
{
    private readonly IProductDeliverSizeRepository _repository;

    public GetProductDeliverSizeByIdHandler(IProductDeliverSizeRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<GetProductDeliverSizeByIdResponse>> Handle(GetProductDeliverSizeByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id);

        if (entity == null)
        {
            return Result<GetProductDeliverSizeByIdResponse>.Fail("ProductDeliverSize not found", 404);
        }

        var response = new GetProductDeliverSizeByIdResponse
        {
            Id = entity.Id,
            ProductSizeId = entity.ProductSizeId,
            ProductDeliverId = entity.ProductDeliverId
        };

        return Result<GetProductDeliverSizeByIdResponse>.Success(response);
    }
}
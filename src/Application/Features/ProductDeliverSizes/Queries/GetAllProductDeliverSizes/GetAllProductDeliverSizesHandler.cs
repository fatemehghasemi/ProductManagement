using MediatR;
using Domain.Common;
using Domain.Interfaces;
using Application.Features.ProductDeliverSizes.Responses;

namespace Application.Features.ProductDeliverSizes.Queries.GetAllProductDeliverSizes;

public class GetAllProductDeliverSizesHandler : IRequestHandler<GetAllProductDeliverSizesQuery, Result<IEnumerable<GetAllProductDeliverSizesResponse>>>
{
    private readonly IProductDeliverSizeRepository _repository;

    public GetAllProductDeliverSizesHandler(IProductDeliverSizeRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<IEnumerable<GetAllProductDeliverSizesResponse>>> Handle(GetAllProductDeliverSizesQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync();

        if (request.ProductDeliverId.HasValue)
        {
            entities = entities.Where(x => x.ProductDeliverId == request.ProductDeliverId.Value).ToList();
        }

        if (request.ProductSizeId.HasValue)
        {
            entities = entities.Where(x => x.ProductSizeId == request.ProductSizeId.Value).ToList();
        }

        var response = entities.Select(x => new GetAllProductDeliverSizesResponse
        {
            Id = x.Id,
            ProductSizeId = x.ProductSizeId,
            ProductDeliverId = x.ProductDeliverId
        });

        return Result<IEnumerable<GetAllProductDeliverSizesResponse>>.Success(response);
    }
}
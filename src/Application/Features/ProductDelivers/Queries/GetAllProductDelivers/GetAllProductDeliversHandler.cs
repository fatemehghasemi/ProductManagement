using Mapster;
using MediatR;
using Domain.Interfaces;
using Domain.Entities;
using Application.Features.ProductDelivers.Responses;
using Domain.Common;

namespace Application.Features.ProductDelivers.Queries.GetAllProductDelivers;

public sealed class GetAllProductDeliversHandler : IRequestHandler<GetAllProductDeliversQuery, Result<IEnumerable<GetAllProductDeliversResponse>>>
{
    private readonly IProductDeliverRepository _productDeliverRepository;

    public GetAllProductDeliversHandler(IProductDeliverRepository productDeliverRepository)
    {
        _productDeliverRepository = productDeliverRepository;
    }

    public async Task<Result<IEnumerable<GetAllProductDeliversResponse>>> Handle(GetAllProductDeliversQuery request, CancellationToken cancellationToken)
    {
        var productDelivers = await _productDeliverRepository.GetAllAsync(cancellationToken);
        
        IEnumerable<ProductDeliver> filteredProductDelivers = productDelivers;
        if (request.ProductId.HasValue)
        {
            filteredProductDelivers = productDelivers.Where(pd => pd.ProductId == request.ProductId.Value);
        }

        var response = filteredProductDelivers.Adapt<IEnumerable<GetAllProductDeliversResponse>>();
        return Result<IEnumerable<GetAllProductDeliversResponse>>.Success(response);
    }
}
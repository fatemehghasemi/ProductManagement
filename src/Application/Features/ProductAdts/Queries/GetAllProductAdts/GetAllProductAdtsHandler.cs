using Mapster;
using MediatR;
using Domain.Interfaces;
using Domain.Entities;
using Application.Features.ProductAdts.Responses;
using Domain.Common;

namespace Application.Features.ProductAdts.Queries.GetAllProductAdts;

public sealed class GetAllProductAdtsHandler : IRequestHandler<GetAllProductAdtsQuery, Result<IEnumerable<GetAllProductAdtsResponse>>>
{
    private readonly IProductAdtRepository _productAdtRepository;

    public GetAllProductAdtsHandler(IProductAdtRepository productAdtRepository)
    {
        _productAdtRepository = productAdtRepository;
    }

    public async Task<Result<IEnumerable<GetAllProductAdtsResponse>>> Handle(GetAllProductAdtsQuery request, CancellationToken cancellationToken)
    {
        var productAdts = await _productAdtRepository.GetAllAsync(cancellationToken);
        
        IEnumerable<ProductAdt> filteredProductAdts = productAdts;
        if (request.ProductId.HasValue)
        {
            filteredProductAdts = productAdts.Where(pa => pa.ProductId == request.ProductId.Value);
        }

        var response = filteredProductAdts.Adapt<IEnumerable<GetAllProductAdtsResponse>>();
        return Result<IEnumerable<GetAllProductAdtsResponse>>.Success(response);
    }
}
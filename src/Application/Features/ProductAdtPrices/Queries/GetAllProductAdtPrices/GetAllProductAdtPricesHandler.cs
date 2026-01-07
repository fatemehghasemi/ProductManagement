using MediatR;
using Domain.Common;
using Domain.Interfaces;
using Application.Features.ProductAdtPrices.Responses;

namespace Application.Features.ProductAdtPrices.Queries.GetAllProductAdtPrices;

public class GetAllProductAdtPricesHandler : IRequestHandler<GetAllProductAdtPricesQuery, Result<IEnumerable<GetAllProductAdtPricesResponse>>>
{
    private readonly IProductAdtPriceRepository _repository;

    public GetAllProductAdtPricesHandler(IProductAdtPriceRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<IEnumerable<GetAllProductAdtPricesResponse>>> Handle(GetAllProductAdtPricesQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync();

        if (request.ProductAdtId.HasValue)
        {
            entities = entities.Where(x => x.ProductAdtId == request.ProductAdtId.Value).ToList();
        }

        var response = entities.Select(x => new GetAllProductAdtPricesResponse
        {
            Id = x.Id,
            ProductAdtId = x.ProductAdtId,
            ProductPriceId = x.ProductPriceId,
            ProductAdtTypeId = x.ProductAdtTypeId,
            Price = x.Price
        });

        return Result<IEnumerable<GetAllProductAdtPricesResponse>>.Success(response);
    }
}
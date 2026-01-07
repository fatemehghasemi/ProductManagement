using MediatR;
using Domain.Common;
using Domain.Interfaces;
using Application.Features.ProductAdtPrices.Responses;

namespace Application.Features.ProductAdtPrices.Queries.GetProductAdtPriceById;

public class GetProductAdtPriceByIdHandler : IRequestHandler<GetProductAdtPriceByIdQuery, Result<GetProductAdtPriceByIdResponse>>
{
    private readonly IProductAdtPriceRepository _repository;

    public GetProductAdtPriceByIdHandler(IProductAdtPriceRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<GetProductAdtPriceByIdResponse>> Handle(GetProductAdtPriceByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id);

        if (entity == null)
        {
            return Result<GetProductAdtPriceByIdResponse>.Fail("ProductAdtPrice not found", 404);
        }

        var response = new GetProductAdtPriceByIdResponse
        {
            Id = entity.Id,
            ProductAdtId = entity.ProductAdtId,
            ProductPriceId = entity.ProductPriceId,
            ProductAdtTypeId = entity.ProductAdtTypeId,
            Price = entity.Price
        };

        return Result<GetProductAdtPriceByIdResponse>.Success(response);
    }
}
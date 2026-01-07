using Mapster;
using MediatR;
using Domain.Interfaces;
using Application.Features.ProductAdts.Responses;
using Domain.Common;

namespace Application.Features.ProductAdts.Queries.GetProductAdtById;

public sealed class GetProductAdtByIdHandler : IRequestHandler<GetProductAdtByIdQuery, Result<GetProductAdtByIdResponse>>
{
    private readonly IProductAdtRepository _productAdtRepository;

    public GetProductAdtByIdHandler(IProductAdtRepository productAdtRepository)
    {
        _productAdtRepository = productAdtRepository;
    }

    public async Task<Result<GetProductAdtByIdResponse>> Handle(GetProductAdtByIdQuery request, CancellationToken cancellationToken)
    {
        var productAdt = await _productAdtRepository.GetByIdAsync(request.Id, cancellationToken);
        if (productAdt == null)
        {
            return Result<GetProductAdtByIdResponse>.Fail("Product ADT not found", 404);
        }

        var response = productAdt.Adapt<GetProductAdtByIdResponse>();
        return Result<GetProductAdtByIdResponse>.Success(response);
    }
}
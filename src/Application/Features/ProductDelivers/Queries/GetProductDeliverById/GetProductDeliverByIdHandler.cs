using Mapster;
using MediatR;
using Domain.Interfaces;
using Application.Features.ProductDelivers.Responses;
using Domain.Common;

namespace Application.Features.ProductDelivers.Queries.GetProductDeliverById;

public sealed class GetProductDeliverByIdHandler : IRequestHandler<GetProductDeliverByIdQuery, Result<GetProductDeliverByIdResponse>>
{
    private readonly IProductDeliverRepository _productDeliverRepository;

    public GetProductDeliverByIdHandler(IProductDeliverRepository productDeliverRepository)
    {
        _productDeliverRepository = productDeliverRepository;
    }

    public async Task<Result<GetProductDeliverByIdResponse>> Handle(GetProductDeliverByIdQuery request, CancellationToken cancellationToken)
    {
        var productDeliver = await _productDeliverRepository.GetByIdAsync(request.Id, cancellationToken);
        if (productDeliver == null)
        {
            return Result<GetProductDeliverByIdResponse>.Fail("Product deliver not found", 404);
        }

        var response = productDeliver.Adapt<GetProductDeliverByIdResponse>();
        return Result<GetProductDeliverByIdResponse>.Success(response);
    }
}
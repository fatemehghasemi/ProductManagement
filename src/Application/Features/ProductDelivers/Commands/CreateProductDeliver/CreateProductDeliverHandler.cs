using Mapster;
using MediatR;
using Domain.Interfaces;
using Application.Features.ProductDelivers.Responses;
using Domain.Common;

namespace Application.Features.ProductDelivers.Commands.CreateProductDeliver;

public sealed class CreateProductDeliverHandler : IRequestHandler<CreateProductDeliverCommand, Result<CreateProductDeliverResponse>>
{
    private readonly IProductDeliverRepository _productDeliverRepository;

    public CreateProductDeliverHandler(IProductDeliverRepository productDeliverRepository)
    {
        _productDeliverRepository = productDeliverRepository;
    }

    public async Task<Result<CreateProductDeliverResponse>> Handle(CreateProductDeliverCommand request, CancellationToken cancellationToken)
    {
        var productDeliver = request.Adapt<Domain.Entities.ProductDeliver>();

        var createdProductDeliver = await _productDeliverRepository.AddAsync(productDeliver, cancellationToken);
        var response = createdProductDeliver.Adapt<CreateProductDeliverResponse>();

        return Result<CreateProductDeliverResponse>.Success(response);
    }
}
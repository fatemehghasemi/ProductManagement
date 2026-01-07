using Mapster;
using MediatR;
using Domain.Interfaces;
using Application.Features.ProductDeliverSizes.Responses;
using Domain.Common;

namespace Application.Features.ProductDeliverSizes.Commands.CreateProductDeliverSize;

public sealed class CreateProductDeliverSizeHandler : IRequestHandler<CreateProductDeliverSizeCommand, Result<CreateProductDeliverSizeResponse>>
{
    private readonly IProductDeliverSizeRepository _repository;

    public CreateProductDeliverSizeHandler(IProductDeliverSizeRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CreateProductDeliverSizeResponse>> Handle(CreateProductDeliverSizeCommand request, CancellationToken cancellationToken)
    {
        var entity = request.Adapt<Domain.Entities.ProductDeliverSize>();

        var created = await _repository.AddAsync(entity, cancellationToken);
        var response = created.Adapt<CreateProductDeliverSizeResponse>();

        return Result<CreateProductDeliverSizeResponse>.Success(response);
    }
}
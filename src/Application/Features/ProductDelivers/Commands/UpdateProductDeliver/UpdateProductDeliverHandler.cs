using Mapster;
using MediatR;
using Domain.Interfaces;
using Application.Features.ProductDelivers.Responses;
using Domain.Common;

namespace Application.Features.ProductDelivers.Commands.UpdateProductDeliver;

public sealed class UpdateProductDeliverHandler : IRequestHandler<UpdateProductDeliverCommand, Result<UpdateProductDeliverResponse>>
{
    private readonly IProductDeliverRepository _productDeliverRepository;

    public UpdateProductDeliverHandler(IProductDeliverRepository productDeliverRepository)
    {
        _productDeliverRepository = productDeliverRepository;
    }

    public async Task<Result<UpdateProductDeliverResponse>> Handle(UpdateProductDeliverCommand request, CancellationToken cancellationToken)
    {
        var existingProductDeliver = await _productDeliverRepository.GetByIdAsync(request.Id, cancellationToken);
        if (existingProductDeliver == null)
        {
            return Result<UpdateProductDeliverResponse>.Fail("Product deliver not found", 404);
        }

        request.Adapt(existingProductDeliver);

        var updatedProductDeliver = await _productDeliverRepository.UpdateAsync(existingProductDeliver, cancellationToken);
        var response = updatedProductDeliver.Adapt<UpdateProductDeliverResponse>();

        return Result<UpdateProductDeliverResponse>.Success(response);
    }
}
using MediatR;
using Domain.Interfaces;
using Domain.Common;

namespace Application.Features.ProductDelivers.Commands.DeleteProductDeliver;

public sealed class DeleteProductDeliverHandler : IRequestHandler<DeleteProductDeliverCommand, Result<bool>>
{
    private readonly IProductDeliverRepository _productDeliverRepository;

    public DeleteProductDeliverHandler(IProductDeliverRepository productDeliverRepository)
    {
        _productDeliverRepository = productDeliverRepository;
    }

    public async Task<Result<bool>> Handle(DeleteProductDeliverCommand request, CancellationToken cancellationToken)
    {
        var exists = await _productDeliverRepository.ExistsAsync(request.Id, cancellationToken);
        if (!exists)
        {
            return Result<bool>.Fail("Product deliver not found", 404);
        }

        var deleted = await _productDeliverRepository.DeleteAsync(request.Id, cancellationToken);
        return Result<bool>.Success(deleted);
    }
}
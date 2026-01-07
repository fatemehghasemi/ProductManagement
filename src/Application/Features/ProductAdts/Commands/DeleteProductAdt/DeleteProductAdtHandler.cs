using MediatR;
using Domain.Interfaces;
using Domain.Common;

namespace Application.Features.ProductAdts.Commands.DeleteProductAdt;

public sealed class DeleteProductAdtHandler : IRequestHandler<DeleteProductAdtCommand, Result<bool>>
{
    private readonly IProductAdtRepository _productAdtRepository;

    public DeleteProductAdtHandler(IProductAdtRepository productAdtRepository)
    {
        _productAdtRepository = productAdtRepository;
    }

    public async Task<Result<bool>> Handle(DeleteProductAdtCommand request, CancellationToken cancellationToken)
    {
        var exists = await _productAdtRepository.ExistsAsync(request.Id);
        if (!exists)
        {
            return Result<bool>.Fail("Product ADT not found", 404);
        }

        var deleted = await _productAdtRepository.DeleteAsync(request.Id);
        return Result<bool>.Success(deleted);
    }
}
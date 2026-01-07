using MediatR;
using Domain.Interfaces;
using Domain.Common;

namespace Application.Features.ProductMaterials.Commands.DeleteProductMaterial;

public sealed class DeleteProductMaterialHandler : IRequestHandler<DeleteProductMaterialCommand, Result<bool>>
{
    private readonly IProductMaterialRepository _productMaterialRepository;

    public DeleteProductMaterialHandler(IProductMaterialRepository productMaterialRepository)
    {
        _productMaterialRepository = productMaterialRepository;
    }

    public async Task<Result<bool>> Handle(DeleteProductMaterialCommand request, CancellationToken cancellationToken)
    {
        var exists = await _productMaterialRepository.ExistsAsync(request.Id, cancellationToken);
        if (!exists)
        {
            return Result<bool>.Fail("Product material not found", 404);
        }

        var deleted = await _productMaterialRepository.DeleteAsync(request.Id, cancellationToken);
        return Result<bool>.Success(deleted);
    }
}
using Mapster;
using MediatR;
using Domain.Interfaces;
using Application.Features.ProductAdts.Responses;
using Domain.Common;

namespace Application.Features.ProductAdts.Commands.UpdateProductAdt;

public sealed class UpdateProductAdtHandler : IRequestHandler<UpdateProductAdtCommand, Result<UpdateProductAdtResponse>>
{
    private readonly IProductAdtRepository _productAdtRepository;

    public UpdateProductAdtHandler(IProductAdtRepository productAdtRepository)
    {
        _productAdtRepository = productAdtRepository;
    }

    public async Task<Result<UpdateProductAdtResponse>> Handle(UpdateProductAdtCommand request, CancellationToken cancellationToken)
    {
        var existingProductAdt = await _productAdtRepository.GetByIdAsync(request.Id);
        if (existingProductAdt == null)
        {
            return Result<UpdateProductAdtResponse>.Fail("Product ADT not found", 404);
        }

        request.Adapt(existingProductAdt);

        var updatedProductAdt = await _productAdtRepository.UpdateAsync(existingProductAdt);
        var response = updatedProductAdt.Adapt<UpdateProductAdtResponse>();

        return Result<UpdateProductAdtResponse>.Success(response);
    }
}
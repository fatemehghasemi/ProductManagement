using Mapster;
using MediatR;
using Domain.Interfaces;
using Application.Features.ProductAdts.Responses;
using Domain.Common;

namespace Application.Features.ProductAdts.Commands.CreateProductAdt;

public sealed class CreateProductAdtHandler : IRequestHandler<CreateProductAdtCommand, Result<CreateProductAdtResponse>>
{
    private readonly IProductAdtRepository _productAdtRepository;

    public CreateProductAdtHandler(IProductAdtRepository productAdtRepository)
    {
        _productAdtRepository = productAdtRepository;
    }

    public async Task<Result<CreateProductAdtResponse>> Handle(CreateProductAdtCommand request, CancellationToken cancellationToken)
    {
        var productAdt = request.Adapt<Domain.Entities.ProductAdt>();

        var createdProductAdt = await _productAdtRepository.AddAsync(productAdt);
        var response = createdProductAdt.Adapt<CreateProductAdtResponse>();

        return Result<CreateProductAdtResponse>.Success(response);
    }
}
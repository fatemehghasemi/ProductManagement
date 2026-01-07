using Mapster;
using MediatR;
using Domain.Interfaces;
using Application.Features.ProductPrintKinds.Responses;
using Domain.Common;

namespace Application.Features.ProductPrintKinds.Commands.CreateProductPrintKind;

public sealed class CreateProductPrintKindHandler : IRequestHandler<CreateProductPrintKindCommand, Result<CreateProductPrintKindResponse>>
{
    private readonly IProductPrintKindRepository _productPrintKindRepository;

    public CreateProductPrintKindHandler(IProductPrintKindRepository productPrintKindRepository)
    {
        _productPrintKindRepository = productPrintKindRepository;
    }

    public async Task<Result<CreateProductPrintKindResponse>> Handle(CreateProductPrintKindCommand request, CancellationToken cancellationToken)
    {
        var productPrintKind = request.Adapt<Domain.Entities.ProductPrintKind>();

        var createdProductPrintKind = await _productPrintKindRepository.AddAsync(productPrintKind, cancellationToken);
        var response = createdProductPrintKind.Adapt<CreateProductPrintKindResponse>();

        return Result<CreateProductPrintKindResponse>.Success(response);
    }
}
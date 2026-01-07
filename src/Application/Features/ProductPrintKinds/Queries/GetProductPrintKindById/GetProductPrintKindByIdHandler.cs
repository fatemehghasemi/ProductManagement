using MediatR;
using Domain.Common;
using Domain.Interfaces;
using Application.Features.ProductPrintKinds.Responses;

namespace Application.Features.ProductPrintKinds.Queries.GetProductPrintKindById;

public class GetProductPrintKindByIdHandler : IRequestHandler<GetProductPrintKindByIdQuery, Result<GetProductPrintKindByIdResponse>>
{
    private readonly IProductPrintKindRepository _repository;

    public GetProductPrintKindByIdHandler(IProductPrintKindRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<GetProductPrintKindByIdResponse>> Handle(GetProductPrintKindByIdQuery request, CancellationToken cancellationToken)
    {
        var productPrintKind = await _repository.GetByIdAsync(request.Id);

        if (productPrintKind == null)
        {
            return Result<GetProductPrintKindByIdResponse>.Fail("ProductPrintKind not found", 404);
        }

        var response = new GetProductPrintKindByIdResponse
        {
            Id = productPrintKind.Id,
            ProductId = productPrintKind.ProductId,
            PrintKindId = productPrintKind.PrintKindId,
            IsJeld = productPrintKind.IsJeld
        };

        return Result<GetProductPrintKindByIdResponse>.Success(response);
    }
}
using MediatR;
using Domain.Common;
using Domain.Interfaces;
using Application.Features.ProductPrintKinds.Responses;

namespace Application.Features.ProductPrintKinds.Queries.GetAllProductPrintKinds;

public class GetAllProductPrintKindsHandler : IRequestHandler<GetAllProductPrintKindsQuery, Result<IEnumerable<GetAllProductPrintKindsResponse>>>
{
    private readonly IProductPrintKindRepository _repository;

    public GetAllProductPrintKindsHandler(IProductPrintKindRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<IEnumerable<GetAllProductPrintKindsResponse>>> Handle(GetAllProductPrintKindsQuery request, CancellationToken cancellationToken)
    {
        var productPrintKinds = await _repository.GetAllAsync();

        if (request.ProductId.HasValue)
        {
            productPrintKinds = productPrintKinds.Where(x => x.ProductId == request.ProductId.Value).ToList();
        }

        var response = productPrintKinds.Select(x => new GetAllProductPrintKindsResponse
        {
            Id = x.Id,
            ProductId = x.ProductId,
            PrintKindId = x.PrintKindId,
            IsJeld = x.IsJeld
        });

        return Result<IEnumerable<GetAllProductPrintKindsResponse>>.Success(response);
    }
}
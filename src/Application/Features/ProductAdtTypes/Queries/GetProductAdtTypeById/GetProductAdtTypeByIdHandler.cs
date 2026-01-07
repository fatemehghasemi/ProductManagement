using MediatR;
using Domain.Common;
using Domain.Interfaces;
using Application.Features.ProductAdtTypes.Responses;

namespace Application.Features.ProductAdtTypes.Queries.GetProductAdtTypeById;

public class GetProductAdtTypeByIdHandler : IRequestHandler<GetProductAdtTypeByIdQuery, Result<GetProductAdtTypeByIdResponse>>
{
    private readonly IProductAdtTypeRepository _repository;

    public GetProductAdtTypeByIdHandler(IProductAdtTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<GetProductAdtTypeByIdResponse>> Handle(GetProductAdtTypeByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id);

        if (entity == null)
        {
            return Result<GetProductAdtTypeByIdResponse>.Fail("ProductAdtType not found", 404);
        }

        var response = new GetProductAdtTypeByIdResponse
        {
            Id = entity.Id,
            ProductAdtId = entity.ProductAdtId,
            AdtTypeId = entity.AdtTypeId
        };

        return Result<GetProductAdtTypeByIdResponse>.Success(response);
    }
}
using MediatR;
using Domain.Common;
using Domain.Interfaces;
using Application.Features.ProductMaterialAttributes.Responses;

namespace Application.Features.ProductMaterialAttributes.Queries.GetProductMaterialAttributeById;

public class GetProductMaterialAttributeByIdHandler : IRequestHandler<GetProductMaterialAttributeByIdQuery, Result<GetProductMaterialAttributeByIdResponse>>
{
    private readonly IProductMaterialAttributeRepository _repository;

    public GetProductMaterialAttributeByIdHandler(IProductMaterialAttributeRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<GetProductMaterialAttributeByIdResponse>> Handle(GetProductMaterialAttributeByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id);

        if (entity == null)
        {
            return Result<GetProductMaterialAttributeByIdResponse>.Fail("ProductMaterialAttribute not found", 404);
        }

        var response = new GetProductMaterialAttributeByIdResponse
        {
            Id = entity.Id,
            ProductMaterialId = entity.ProductMaterialId,
            MaterialAttributeId = entity.MaterialAttributeId
        };

        return Result<GetProductMaterialAttributeByIdResponse>.Success(response);
    }
}
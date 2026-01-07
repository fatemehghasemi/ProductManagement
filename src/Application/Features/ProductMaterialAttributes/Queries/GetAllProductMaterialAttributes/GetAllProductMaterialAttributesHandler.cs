using MediatR;
using Domain.Common;
using Domain.Interfaces;
using Application.Features.ProductMaterialAttributes.Responses;

namespace Application.Features.ProductMaterialAttributes.Queries.GetAllProductMaterialAttributes;

public class GetAllProductMaterialAttributesHandler : IRequestHandler<GetAllProductMaterialAttributesQuery, Result<IEnumerable<GetAllProductMaterialAttributesResponse>>>
{
    private readonly IProductMaterialAttributeRepository _repository;

    public GetAllProductMaterialAttributesHandler(IProductMaterialAttributeRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<IEnumerable<GetAllProductMaterialAttributesResponse>>> Handle(GetAllProductMaterialAttributesQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync();

        if (request.ProductMaterialId.HasValue)
        {
            entities = entities.Where(x => x.ProductMaterialId == request.ProductMaterialId.Value).ToList();
        }

        var response = entities.Select(x => new GetAllProductMaterialAttributesResponse
        {
            Id = x.Id,
            ProductMaterialId = x.ProductMaterialId,
            MaterialAttributeId = x.MaterialAttributeId
        });

        return Result<IEnumerable<GetAllProductMaterialAttributesResponse>>.Success(response);
    }
}
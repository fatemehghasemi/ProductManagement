using MediatR;
using Domain.Common;
using Domain.Interfaces;
using Application.Features.ProductAdtTypes.Responses;

namespace Application.Features.ProductAdtTypes.Queries.GetAllProductAdtTypes;

public class GetAllProductAdtTypesHandler : IRequestHandler<GetAllProductAdtTypesQuery, Result<IEnumerable<GetAllProductAdtTypesResponse>>>
{
    private readonly IProductAdtTypeRepository _repository;

    public GetAllProductAdtTypesHandler(IProductAdtTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<IEnumerable<GetAllProductAdtTypesResponse>>> Handle(GetAllProductAdtTypesQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync();

        if (request.ProductAdtId.HasValue)
        {
            entities = entities.Where(x => x.ProductAdtId == request.ProductAdtId.Value).ToList();
        }

        var response = entities.Select(x => new GetAllProductAdtTypesResponse
        {
            Id = x.Id,
            ProductAdtId = x.ProductAdtId,
            AdtTypeId = x.AdtTypeId
        });

        return Result<IEnumerable<GetAllProductAdtTypesResponse>>.Success(response);
    }
}
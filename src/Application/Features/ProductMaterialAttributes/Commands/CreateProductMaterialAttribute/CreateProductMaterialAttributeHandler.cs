using Mapster;
using MediatR;
using Domain.Interfaces;
using Application.Features.ProductMaterialAttributes.Responses;
using Domain.Common;

namespace Application.Features.ProductMaterialAttributes.Commands.CreateProductMaterialAttribute;

public sealed class CreateProductMaterialAttributeHandler : IRequestHandler<CreateProductMaterialAttributeCommand, Result<CreateProductMaterialAttributeResponse>>
{
    private readonly IProductMaterialAttributeRepository _repository;

    public CreateProductMaterialAttributeHandler(IProductMaterialAttributeRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CreateProductMaterialAttributeResponse>> Handle(CreateProductMaterialAttributeCommand request, CancellationToken cancellationToken)
    {
        var entity = request.Adapt<Domain.Entities.ProductMaterialAttribute>();

        var created = await _repository.AddAsync(entity, cancellationToken);
        var response = created.Adapt<CreateProductMaterialAttributeResponse>();

        return Result<CreateProductMaterialAttributeResponse>.Success(response);
    }
}
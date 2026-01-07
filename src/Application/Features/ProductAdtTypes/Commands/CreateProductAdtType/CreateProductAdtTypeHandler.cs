using Mapster;
using MediatR;
using Domain.Interfaces;
using Application.Features.ProductAdtTypes.Responses;
using Domain.Common;

namespace Application.Features.ProductAdtTypes.Commands.CreateProductAdtType;

public sealed class CreateProductAdtTypeHandler : IRequestHandler<CreateProductAdtTypeCommand, Result<CreateProductAdtTypeResponse>>
{
    private readonly IProductAdtTypeRepository _productAdtTypeRepository;

    public CreateProductAdtTypeHandler(IProductAdtTypeRepository productAdtTypeRepository)
    {
        _productAdtTypeRepository = productAdtTypeRepository;
    }

    public async Task<Result<CreateProductAdtTypeResponse>> Handle(CreateProductAdtTypeCommand request, CancellationToken cancellationToken)
    {
        var productAdtType = request.Adapt<Domain.Entities.ProductAdtType>();

        var createdProductAdtType = await _productAdtTypeRepository.AddAsync(productAdtType, cancellationToken);
        var response = createdProductAdtType.Adapt<CreateProductAdtTypeResponse>();

        return Result<CreateProductAdtTypeResponse>.Success(response);
    }
}
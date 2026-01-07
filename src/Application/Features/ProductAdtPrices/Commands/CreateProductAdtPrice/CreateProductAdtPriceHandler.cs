using Mapster;
using MediatR;
using Domain.Interfaces;
using Application.Features.ProductAdtPrices.Responses;
using Domain.Common;

namespace Application.Features.ProductAdtPrices.Commands.CreateProductAdtPrice;

public sealed class CreateProductAdtPriceHandler : IRequestHandler<CreateProductAdtPriceCommand, Result<CreateProductAdtPriceResponse>>
{
    private readonly IProductAdtPriceRepository _repository;

    public CreateProductAdtPriceHandler(IProductAdtPriceRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CreateProductAdtPriceResponse>> Handle(CreateProductAdtPriceCommand request, CancellationToken cancellationToken)
    {
        var entity = request.Adapt<Domain.Entities.ProductAdtPrice>();

        var created = await _repository.AddAsync(entity, cancellationToken);
        var response = created.Adapt<CreateProductAdtPriceResponse>();

        return Result<CreateProductAdtPriceResponse>.Success(response);
    }
}
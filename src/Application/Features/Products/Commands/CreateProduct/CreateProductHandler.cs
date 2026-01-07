using Mapster;
using MediatR;
using Domain.Interfaces;
using Application.Features.Products.Responses;
using Domain.Common;
using Domain.Factories;

namespace Application.Features.Products.Commands.CreateProduct;

public sealed class CreateProductHandler : IRequestHandler<CreateProductCommand, Result<CreateProductResponse>>
{
    private readonly IProductRepository _productRepository;
    private readonly IEntityFactory<Domain.Entities.Product, ProductCreationModel> _productFactory;

    public CreateProductHandler(
        IProductRepository productRepository,
        IEntityFactory<Domain.Entities.Product, ProductCreationModel> productFactory)
    {
        _productRepository = productRepository;
        _productFactory = productFactory;
    }

    public async Task<Result<CreateProductResponse>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        try
        {
            // Map command to creation model
            var creationModel = request.Adapt<ProductCreationModel>();
            
            // Use factory to create product with business rules
            var product = await _productFactory.CreateAsync(creationModel);

            // Save to repository
            var createdProduct = await _productRepository.AddAsync(product);
            var response = createdProduct.Adapt<CreateProductResponse>();

            return Result<CreateProductResponse>.Success(response);
        }
        catch (InvalidOperationException ex)
        {
            return Result<CreateProductResponse>.Fail(ex.Message, 400);
        }
        catch (Exception ex)
        {
            return Result<CreateProductResponse>.Fail($"An error occurred while creating the product: {ex.Message}", 500);
        }
    }
}
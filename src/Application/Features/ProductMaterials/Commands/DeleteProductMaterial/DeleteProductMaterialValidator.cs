using FluentValidation;

namespace Application.Features.ProductMaterials.Commands.DeleteProductMaterial;

public sealed class DeleteProductMaterialValidator : AbstractValidator<DeleteProductMaterialCommand>
{
    public DeleteProductMaterialValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Product Material ID must be greater than 0");
    }
}
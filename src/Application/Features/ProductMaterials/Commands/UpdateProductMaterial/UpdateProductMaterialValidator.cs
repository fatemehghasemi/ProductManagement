using FluentValidation;

namespace Application.Features.ProductMaterials.Commands.UpdateProductMaterial;

public sealed class UpdateProductMaterialValidator : AbstractValidator<UpdateProductMaterialCommand>
{
    public UpdateProductMaterialValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Product Material ID must be greater than 0");

        RuleFor(x => x.ProductId)
            .GreaterThan(0).WithMessage("Product ID must be greater than 0");

        RuleFor(x => x.MaterialId)
            .GreaterThan(0).WithMessage("Material ID must be greater than 0");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(100).WithMessage("Name cannot exceed 100 characters");

        RuleFor(x => x.Weight)
            .GreaterThan(0).WithMessage("Weight must be greater than 0")
            .When(x => x.Weight.HasValue);
    }
}
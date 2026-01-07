using FluentValidation;

namespace Application.Features.ProductMaterialAttributes.Commands.CreateProductMaterialAttribute;

public sealed class CreateProductMaterialAttributeValidator : AbstractValidator<CreateProductMaterialAttributeCommand>
{
    public CreateProductMaterialAttributeValidator()
    {
        RuleFor(x => x.ProductMaterialId)
            .GreaterThan(0).WithMessage("Product Material ID must be greater than 0");

        RuleFor(x => x.MaterialAttributeId)
            .GreaterThan(0).WithMessage("Material Attribute ID must be greater than 0");
    }
}
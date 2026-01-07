using FluentValidation;

namespace Application.Features.ProductPrices.Commands.CreateProductPrice;

public sealed class CreateProductPriceValidator : AbstractValidator<CreateProductPriceCommand>
{
    public CreateProductPriceValidator()
    {
        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0");

        RuleFor(x => x.Circulation)
            .GreaterThan(0).WithMessage("Circulation must be greater than 0");

        RuleFor(x => x.ProductSizeId)
            .GreaterThan(0).WithMessage("Product Size ID must be greater than 0");

        RuleFor(x => x.ProductMaterialId)
            .GreaterThan(0).WithMessage("Product Material ID must be greater than 0");

        RuleFor(x => x.ProductPrintKindId)
            .GreaterThan(0).WithMessage("Product Print Kind ID must be greater than 0");

        RuleFor(x => x.PageCount)
            .GreaterThan(0).WithMessage("Page Count must be greater than 0")
            .When(x => x.PageCount.HasValue);

        RuleFor(x => x.CopyCount)
            .GreaterThan(0).WithMessage("Copy Count must be greater than 0")
            .When(x => x.CopyCount.HasValue);

        RuleFor(x => x.ProductMaterialAttributeId)
            .GreaterThan(0).WithMessage("Product Material Attribute ID must be greater than 0")
            .When(x => x.ProductMaterialAttributeId.HasValue);
    }
}
using FluentValidation;

namespace Application.Features.ProductSizes.Commands.UpdateProductSize;

public sealed class UpdateProductSizeValidator : AbstractValidator<UpdateProductSizeCommand>
{
    public UpdateProductSizeValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Product Size ID must be greater than 0");

        RuleFor(x => x.ProductId)
            .GreaterThan(0).WithMessage("Product ID must be greater than 0");

        RuleFor(x => x.Length)
            .GreaterThan(0).WithMessage("Length must be greater than 0");

        RuleFor(x => x.Width)
            .GreaterThan(0).WithMessage("Width must be greater than 0");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(100).WithMessage("Name cannot exceed 100 characters");

        RuleFor(x => x.SheetDimensionId)
            .GreaterThan(0).WithMessage("Sheet Dimension ID must be greater than 0");

        RuleFor(x => x.SheetCount)
            .GreaterThan(0).WithMessage("Sheet Count must be greater than 0")
            .When(x => x.SheetCount.HasValue);
    }
}
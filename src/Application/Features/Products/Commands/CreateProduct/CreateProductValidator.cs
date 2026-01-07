using FluentValidation;

namespace Application.Features.Products.Commands.CreateProduct;

public sealed class CreateProductValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductValidator()
    {
        RuleFor(x => x.ProductGroupId)
            .GreaterThan(0).WithMessage("Product Group ID must be greater than 0");

        RuleFor(x => x.WorkTypeId)
            .GreaterThan(0).WithMessage("Work Type ID must be greater than 0");

        RuleFor(x => x.Circulation)
            .NotEmpty().WithMessage("Circulation is required")
            .MaximumLength(50).WithMessage("Circulation cannot exceed 50 characters");

        RuleFor(x => x.CopyCount)
            .NotEmpty().WithMessage("Copy Count is required")
            .MaximumLength(50).WithMessage("Copy Count cannot exceed 50 characters");

        RuleFor(x => x.PageCount)
            .NotEmpty().WithMessage("Page Count is required")
            .MaximumLength(50).WithMessage("Page Count cannot exceed 50 characters");

        RuleFor(x => x.FileExtension)
            .NotEmpty().WithMessage("File Extension is required")
            .MaximumLength(10).WithMessage("File Extension cannot exceed 10 characters");

        RuleFor(x => x.SheetDimensionId)
            .GreaterThan(0).WithMessage("Sheet Dimension ID must be greater than 0");
    }
}
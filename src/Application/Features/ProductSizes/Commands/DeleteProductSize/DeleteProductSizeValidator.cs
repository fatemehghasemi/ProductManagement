using FluentValidation;

namespace Application.Features.ProductSizes.Commands.DeleteProductSize;

public sealed class DeleteProductSizeValidator : AbstractValidator<DeleteProductSizeCommand>
{
    public DeleteProductSizeValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Product Size ID must be greater than 0");
    }
}
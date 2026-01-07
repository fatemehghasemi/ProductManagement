using FluentValidation;

namespace Application.Features.ProductAdts.Commands.DeleteProductAdt;

public sealed class DeleteProductAdtValidator : AbstractValidator<DeleteProductAdtCommand>
{
    public DeleteProductAdtValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Product ADT ID must be greater than 0");
    }
}
using FluentValidation;

namespace Application.Features.ProductAdts.Commands.CreateProductAdt;

public sealed class CreateProductAdtValidator : AbstractValidator<CreateProductAdtCommand>
{
    public CreateProductAdtValidator()
    {
        RuleFor(x => x.AdtId)
            .GreaterThan(0).WithMessage("ADT ID must be greater than 0");

        RuleFor(x => x.ProductId)
            .GreaterThan(0).WithMessage("Product ID must be greater than 0");

        RuleFor(x => x.Side)
            .GreaterThan((byte)0).WithMessage("Side must be greater than 0")
            .When(x => x.Side.HasValue);

        RuleFor(x => x.Count)
            .GreaterThan(0).WithMessage("Count must be greater than 0")
            .When(x => x.Count.HasValue);
    }
}
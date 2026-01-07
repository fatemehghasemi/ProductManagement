using FluentValidation;

namespace Application.Features.ProductPrintKinds.Commands.CreateProductPrintKind;

public sealed class CreateProductPrintKindValidator : AbstractValidator<CreateProductPrintKindCommand>
{
    public CreateProductPrintKindValidator()
    {
        RuleFor(x => x.ProductId)
            .GreaterThan(0).WithMessage("Product ID must be greater than 0");

        RuleFor(x => x.PrintKindId)
            .GreaterThan(0).WithMessage("Print Kind ID must be greater than 0");
    }
}
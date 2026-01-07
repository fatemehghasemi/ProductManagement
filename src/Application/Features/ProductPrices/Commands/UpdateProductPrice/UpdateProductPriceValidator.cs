using FluentValidation;

namespace Application.Features.ProductPrices.Commands.UpdateProductPrice;

public sealed class UpdateProductPriceValidator : AbstractValidator<UpdateProductPriceCommand>
{
    public UpdateProductPriceValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Product Price ID must be greater than 0");

        RuleFor(x => x.ProductId)
            .GreaterThan(0).WithMessage("Product ID must be greater than 0");

        RuleFor(x => x.CirculationFrom)
            .GreaterThan(0).WithMessage("Circulation From must be greater than 0");

        RuleFor(x => x.CirculationTo)
            .GreaterThan(0).WithMessage("Circulation To must be greater than 0")
            .GreaterThan(x => x.CirculationFrom).WithMessage("Circulation To must be greater than Circulation From");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0");
    }
}
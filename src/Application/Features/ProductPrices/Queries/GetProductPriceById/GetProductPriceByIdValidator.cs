using FluentValidation;

namespace Application.Features.ProductPrices.Queries.GetProductPriceById;

public sealed class GetProductPriceByIdValidator : AbstractValidator<GetProductPriceByIdQuery>
{
    public GetProductPriceByIdValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Product Price ID must be greater than 0");
    }
}
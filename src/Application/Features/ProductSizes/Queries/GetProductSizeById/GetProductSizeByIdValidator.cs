using FluentValidation;

namespace Application.Features.ProductSizes.Queries.GetProductSizeById;

public sealed class GetProductSizeByIdValidator : AbstractValidator<GetProductSizeByIdQuery>
{
    public GetProductSizeByIdValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Product Size ID must be greater than 0");
    }
}
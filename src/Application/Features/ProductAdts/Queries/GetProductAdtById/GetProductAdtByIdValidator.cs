using FluentValidation;

namespace Application.Features.ProductAdts.Queries.GetProductAdtById;

public sealed class GetProductAdtByIdValidator : AbstractValidator<GetProductAdtByIdQuery>
{
    public GetProductAdtByIdValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Product ADT ID must be greater than 0");
    }
}
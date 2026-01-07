using FluentValidation;

namespace Application.Features.ProductDelivers.Queries.GetProductDeliverById;

public sealed class GetProductDeliverByIdValidator : AbstractValidator<GetProductDeliverByIdQuery>
{
    public GetProductDeliverByIdValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Product Deliver ID must be greater than 0");
    }
}
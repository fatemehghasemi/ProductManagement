using FluentValidation;

namespace Application.Features.ProductDelivers.Commands.DeleteProductDeliver;

public sealed class DeleteProductDeliverValidator : AbstractValidator<DeleteProductDeliverCommand>
{
    public DeleteProductDeliverValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Product Deliver ID must be greater than 0");
    }
}
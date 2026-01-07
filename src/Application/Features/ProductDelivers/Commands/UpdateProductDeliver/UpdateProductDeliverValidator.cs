using FluentValidation;

namespace Application.Features.ProductDelivers.Commands.UpdateProductDeliver;

public sealed class UpdateProductDeliverValidator : AbstractValidator<UpdateProductDeliverCommand>
{
    public UpdateProductDeliverValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Product Deliver ID must be greater than 0");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(100).WithMessage("Name cannot exceed 100 characters");

        RuleFor(x => x.ProductId)
            .GreaterThan(0).WithMessage("Product ID must be greater than 0");

        RuleFor(x => x.DeliverId)
            .GreaterThan(0).WithMessage("Deliver ID must be greater than 0");

        RuleFor(x => x.Weight)
            .GreaterThan(0).WithMessage("Weight must be greater than 0")
            .When(x => x.Weight.HasValue);
    }
}
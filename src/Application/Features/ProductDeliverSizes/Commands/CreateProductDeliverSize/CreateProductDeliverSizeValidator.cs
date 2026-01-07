using FluentValidation;

namespace Application.Features.ProductDeliverSizes.Commands.CreateProductDeliverSize;

public sealed class CreateProductDeliverSizeValidator : AbstractValidator<CreateProductDeliverSizeCommand>
{
    public CreateProductDeliverSizeValidator()
    {
        RuleFor(x => x.ProductSizeId)
            .GreaterThan(0).WithMessage("Product Size ID must be greater than 0");

        RuleFor(x => x.ProductDeliverId)
            .GreaterThan(0).WithMessage("Product Deliver ID must be greater than 0");
    }
}
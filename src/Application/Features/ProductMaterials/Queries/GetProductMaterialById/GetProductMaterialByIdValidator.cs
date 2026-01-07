using FluentValidation;

namespace Application.Features.ProductMaterials.Queries.GetProductMaterialById;

public sealed class GetProductMaterialByIdValidator : AbstractValidator<GetProductMaterialByIdQuery>
{
    public GetProductMaterialByIdValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Product Material ID must be greater than 0");
    }
}
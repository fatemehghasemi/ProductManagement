using MediatR;
using Application.Features.ProductMaterialAttributes.Responses;
using Domain.Common;

namespace Application.Features.ProductMaterialAttributes.Commands.CreateProductMaterialAttribute;

public record CreateProductMaterialAttributeCommand(
    int ProductMaterialId,
    int MaterialAttributeId
) : IRequest<Result<CreateProductMaterialAttributeResponse>>;
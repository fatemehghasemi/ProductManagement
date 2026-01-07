using MediatR;
using Application.Features.ProductAdts.Responses;
using Domain.Common;

namespace Application.Features.ProductAdts.Commands.UpdateProductAdt;

public record UpdateProductAdtCommand(
    int Id,
    int AdtId,
    int ProductId,
    bool Required,
    byte? Side,
    int? Count,
    bool IsJeld
) : IRequest<Result<UpdateProductAdtResponse>>;
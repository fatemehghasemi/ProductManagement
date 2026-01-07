using MediatR;
using Application.Features.ProductAdtTypes.Responses;
using Domain.Common;

namespace Application.Features.ProductAdtTypes.Commands.CreateProductAdtType;

public record CreateProductAdtTypeCommand(
    int ProductAdtId,
    int AdtTypeId
) : IRequest<Result<CreateProductAdtTypeResponse>>;
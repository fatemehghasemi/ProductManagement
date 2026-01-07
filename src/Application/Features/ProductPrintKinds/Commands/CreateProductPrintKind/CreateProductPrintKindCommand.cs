using MediatR;
using Application.Features.ProductPrintKinds.Responses;
using Domain.Common;

namespace Application.Features.ProductPrintKinds.Commands.CreateProductPrintKind;

public record CreateProductPrintKindCommand(
    int ProductId,
    int PrintKindId,
    bool IsJeld
) : IRequest<Result<CreateProductPrintKindResponse>>;
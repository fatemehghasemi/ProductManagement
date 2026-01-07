using MediatR;
using Application.Features.ProductPrintKinds.Responses;
using Domain.Common;

namespace Application.Features.ProductPrintKinds.Queries.GetProductPrintKindById;

public record GetProductPrintKindByIdQuery(int Id) : IRequest<Result<GetProductPrintKindByIdResponse>>;
using MediatR;
using Application.Features.ProductPrintKinds.Responses;
using Domain.Common;

namespace Application.Features.ProductPrintKinds.Queries.GetAllProductPrintKinds;

public record GetAllProductPrintKindsQuery(int? ProductId = null) : IRequest<Result<IEnumerable<GetAllProductPrintKindsResponse>>>;
using MediatR;
using Application.Features.ProductAdtTypes.Responses;
using Domain.Common;

namespace Application.Features.ProductAdtTypes.Queries.GetAllProductAdtTypes;

public record GetAllProductAdtTypesQuery(int? ProductAdtId = null) : IRequest<Result<IEnumerable<GetAllProductAdtTypesResponse>>>;
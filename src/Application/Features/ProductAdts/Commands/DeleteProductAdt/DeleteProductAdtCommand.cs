using MediatR;
using Domain.Common;

namespace Application.Features.ProductAdts.Commands.DeleteProductAdt;

public record DeleteProductAdtCommand(int Id) : IRequest<Result<bool>>;
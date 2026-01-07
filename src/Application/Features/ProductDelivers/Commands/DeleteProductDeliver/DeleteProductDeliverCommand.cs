using MediatR;
using Domain.Common;

namespace Application.Features.ProductDelivers.Commands.DeleteProductDeliver;

public record DeleteProductDeliverCommand(int Id) : IRequest<Result<bool>>;
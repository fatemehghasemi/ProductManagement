using MediatR;
using Domain.Common;

namespace Application.Features.ProductSizes.Commands.DeleteProductSize;

public record DeleteProductSizeCommand(int Id) : IRequest<Result<bool>>;
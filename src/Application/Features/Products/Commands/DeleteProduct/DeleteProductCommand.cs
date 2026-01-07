using MediatR;
using Domain.Common;

namespace Application.Features.Products.Commands.DeleteProduct;

public record DeleteProductCommand(int Id) : IRequest<Result<bool>>;
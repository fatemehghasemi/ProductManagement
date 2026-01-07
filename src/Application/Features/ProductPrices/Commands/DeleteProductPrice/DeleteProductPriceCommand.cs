using MediatR;
using Domain.Common;

namespace Application.Features.ProductPrices.Commands.DeleteProductPrice;

public record DeleteProductPriceCommand(int Id) : IRequest<Result<bool>>;
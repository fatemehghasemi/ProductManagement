using MediatR;
using Domain.Common;

namespace Application.Features.ProductMaterials.Commands.DeleteProductMaterial;

public record DeleteProductMaterialCommand(int Id) : IRequest<Result<bool>>;
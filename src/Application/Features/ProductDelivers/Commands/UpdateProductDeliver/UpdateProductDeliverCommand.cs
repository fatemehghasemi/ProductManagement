using MediatR;
using Application.Features.ProductDelivers.Responses;
using Domain.Common;

namespace Application.Features.ProductDelivers.Commands.UpdateProductDeliver;

public record UpdateProductDeliverCommand(
    int Id,
    string Name,
    int ProductId,
    int DeliverId,
    bool Required,
    bool IsJeld,
    bool IsCustomCirculation,
    bool IsCombinedDeliver,
    int? Weight
) : IRequest<Result<UpdateProductDeliverResponse>>;
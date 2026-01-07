using MediatR;
using Application.Features.Products.Responses;
using Domain.Common;

namespace Application.Features.Products.Commands.UpdateProduct;

public record UpdateProductCommand(
    int Id,
    int ProductGroupId,
    int WorkTypeId,
    byte ProductType,
    string Circulation,
    string CopyCount,
    string PageCount,
    byte PrintSide,
    bool IsCalculatePrice,
    bool IsCustomCirculation,
    bool IsCustomSize,
    bool IsCustomPage,
    int? MinCirculation,
    int? MaxCirculation,
    int? MinPage,
    int? MaxPage,
    float? MinWidth,
    float? MaxWidth,
    float? MinLength,
    float? MaxLength,
    int SheetDimensionId,
    string FileExtension,
    bool IsCmyk,
    float CutMargin,
    float PrintMargin,
    bool IsCheckFile
) : IRequest<Result<UpdateProductResponse>>;
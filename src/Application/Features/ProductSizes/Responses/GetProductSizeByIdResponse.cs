namespace Application.Features.ProductSizes.Responses;

public class GetProductSizeByIdResponse
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public float Length { get; set; }
    public float Width { get; set; }
    public string Name { get; set; } = string.Empty;
    public int? SheetCount { get; set; }
    public int SheetDimensionId { get; set; }
}
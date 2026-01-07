namespace Application.Features.ProductDeliverSizes.Responses;

public class CreateProductDeliverSizeResponse
{
    public int Id { get; set; }
    public int ProductSizeId { get; set; }
    public int ProductDeliverId { get; set; }
}
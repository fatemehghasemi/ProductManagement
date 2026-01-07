namespace Application.Features.ProductAdtPrices.Responses;

public class CreateProductAdtPriceResponse
{
    public int Id { get; set; }
    public int ProductAdtId { get; set; }
    public int ProductPriceId { get; set; }
    public int ProductAdtTypeId { get; set; }
    public float Price { get; set; }
}
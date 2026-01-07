namespace Application.Features.ProductPrices.Responses;

public class GetProductPriceByIdResponse
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int CirculationFrom { get; set; }
    public int CirculationTo { get; set; }
    public float Price { get; set; }
}
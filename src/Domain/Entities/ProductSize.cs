namespace Domain.Entities;

public class ProductSize
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public float Length { get; set; }
    public float Width { get; set; }
    public string Name { get; set; }
    public int? SheetCount { get; set; }
    public int SheetDimensionId { get; set; }

    public Product Product { get; set; }
    public ICollection<ProductDeliverSize> DeliverSizes { get; set; }
}
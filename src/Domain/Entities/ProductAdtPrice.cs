namespace Domain.Entities;

public class ProductAdtPrice
{
    public int Id { get; set; }
    public int ProductAdtId { get; set; }
    public int ProductPriceId { get; set; }
    public int ProductAdtTypeId { get; set; }
    public float Price { get; set; }

    public ProductAdt ProductAdt { get; set; }
}
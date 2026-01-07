namespace Domain.Entities;

public class ProductAdt
{
    public int Id { get; set; }
    public int AdtId { get; set; }
    public int ProductId { get; set; }
    public bool Required { get; set; }
    public byte? Side { get; set; }
    public int? Count { get; set; }
    public bool IsJeld { get; set; }

    public Product Product { get; set; }
    public ICollection<ProductAdtType> Types { get; set; }
    public ICollection<ProductAdtPrice> Prices { get; set; }
}
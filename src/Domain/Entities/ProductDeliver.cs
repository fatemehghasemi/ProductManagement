namespace Domain.Entities;

public class ProductDeliver
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string Name { get; set; }
    public bool IsIncreased { get; set; }
    public int StartCirculation { get; set; }
    public int EndCirculation { get; set; }
    public byte PrintSide { get; set; }
    public float Price { get; set; }
    public byte CalcType { get; set; }

    public Product Product { get; set; }
    public ICollection<ProductDeliverSize> Sizes { get; set; }
}
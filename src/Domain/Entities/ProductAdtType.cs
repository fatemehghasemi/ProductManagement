namespace Domain.Entities;

public class ProductAdtType
{
    public int Id { get; set; }
    public int ProductAdtId { get; set; }
    public int AdtTypeId { get; set; }

    public ProductAdt ProductAdt { get; set; }
}
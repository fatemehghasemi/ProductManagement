namespace Domain.Entities;

public class ProductPrintKind
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int PrintKindId { get; set; }
    public bool IsJeld { get; set; }

    public Product Product { get; set; }
}
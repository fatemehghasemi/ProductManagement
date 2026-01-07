namespace Application.Features.ProductPrintKinds.Responses;

public class UpdateProductPrintKindResponse
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int PrintKindId { get; set; }
    public bool Required { get; set; }
    public bool IsJeld { get; set; }
    public int? Count { get; set; }
}
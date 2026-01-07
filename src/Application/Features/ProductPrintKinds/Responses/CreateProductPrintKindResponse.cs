namespace Application.Features.ProductPrintKinds.Responses;

public class CreateProductPrintKindResponse
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int PrintKindId { get; set; }
    public bool IsJeld { get; set; }
}
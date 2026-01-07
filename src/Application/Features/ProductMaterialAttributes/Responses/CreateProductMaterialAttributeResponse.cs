namespace Application.Features.ProductMaterialAttributes.Responses;

public class CreateProductMaterialAttributeResponse
{
    public int Id { get; set; }
    public int ProductMaterialId { get; set; }
    public int MaterialAttributeId { get; set; }
}
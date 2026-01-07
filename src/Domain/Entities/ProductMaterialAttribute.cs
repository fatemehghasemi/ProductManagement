namespace Domain.Entities;

public class ProductMaterialAttribute
{
    public int Id { get; set; }
    public int ProductMaterialId { get; set; }
    public int MaterialAttributeId { get; set; }

    public ProductMaterial ProductMaterial { get; set; }
}
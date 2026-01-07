namespace Application.Features.ProductMaterials.Responses;

public class CreateProductMaterialResponse
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int MaterialId { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsJeld { get; set; }
    public bool Required { get; set; }
    public bool IsCustomCirculation { get; set; }
    public bool IsCombinedMaterial { get; set; }
    public int? Weight { get; set; }
}
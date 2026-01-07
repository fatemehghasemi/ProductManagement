namespace Domain.Entities;

public class ProductMaterial
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int MaterialId { get; set; }
    public string Name { get; set; }
    public bool IsJeld { get; set; }
    public bool Required { get; set; }
    public bool IsCustomCirculation { get; set; }
    public bool IsCombinedMaterial { get; set; }
    public int? Weight { get; set; }

    public Product Product { get; set; }
    public ICollection<ProductMaterialAttribute> Attributes { get; set; }
}
using Domain.Entities;

namespace Domain.Factories;

/// <summary>
/// Factory for creating Product entities with business rules and validation
/// </summary>
public class ProductFactory : IEntityFactory<Product, ProductCreationModel>
{
    public Product Create(ProductCreationModel model)
    {
        var product = new Product
        {
            ProductGroupId = model.ProductGroupId,
            WorkTypeId = model.WorkTypeId,
            ProductType = model.ProductType,
            Circulation = model.Circulation,
            CopyCount = model.CopyCount,
            PageCount = model.PageCount,
            PrintSide = model.PrintSide,
            IsDelete = false, // Default value
            IsCalculatePrice = model.IsCalculatePrice,
            IsCustomCirculation = model.IsCustomCirculation,
            IsCustomSize = model.IsCustomSize,
            IsCustomPage = model.IsCustomPage,
            MinCirculation = model.MinCirculation,
            MaxCirculation = model.MaxCirculation,
            MinPage = model.MinPage,
            MaxPage = model.MaxPage,
            MinWidth = model.MinWidth,
            MaxWidth = model.MaxWidth,
            MinLength = model.MinLength,
            MaxLength = model.MaxLength,
            SheetDimensionId = model.SheetDimensionId,
            FileExtension = model.FileExtension,
            IsCmyk = model.IsCmyk,
            CutMargin = model.CutMargin,
            PrintMargin = model.PrintMargin,
            IsCheckFile = model.IsCheckFile
        };

        // Apply business rules
        ApplyBusinessRules(product);
        
        return product;
    }

    public async Task<Product> CreateAsync(ProductCreationModel model)
    {
        // For async operations like external validations
        await Task.CompletedTask;
        return Create(model);
    }

    private static void ApplyBusinessRules(Product product)
    {
        // Business rule: If custom circulation is enabled, min/max must be set
        if (product.IsCustomCirculation && (!product.MinCirculation.HasValue || !product.MaxCirculation.HasValue))
        {
            throw new InvalidOperationException("Custom circulation requires min and max circulation values");
        }

        // Business rule: If custom size is enabled, min/max dimensions must be set
        if (product.IsCustomSize && (!product.MinWidth.HasValue || !product.MaxWidth.HasValue || 
                                    !product.MinLength.HasValue || !product.MaxLength.HasValue))
        {
            throw new InvalidOperationException("Custom size requires min and max dimension values");
        }

        // Business rule: If custom page is enabled, min/max pages must be set
        if (product.IsCustomPage && (!product.MinPage.HasValue || !product.MaxPage.HasValue))
        {
            throw new InvalidOperationException("Custom page requires min and max page values");
        }
    }
}

/// <summary>
/// Model for creating Product entities
/// </summary>
public class ProductCreationModel
{
    public int ProductGroupId { get; set; }
    public int WorkTypeId { get; set; }
    public byte ProductType { get; set; }
    public string Circulation { get; set; } = string.Empty;
    public string CopyCount { get; set; } = string.Empty;
    public string PageCount { get; set; } = string.Empty;
    public byte PrintSide { get; set; }
    public bool IsCalculatePrice { get; set; }
    public bool IsCustomCirculation { get; set; }
    public bool IsCustomSize { get; set; }
    public bool IsCustomPage { get; set; }
    public int? MinCirculation { get; set; }
    public int? MaxCirculation { get; set; }
    public int? MinPage { get; set; }
    public int? MaxPage { get; set; }
    public float? MinWidth { get; set; }
    public float? MaxWidth { get; set; }
    public float? MinLength { get; set; }
    public float? MaxLength { get; set; }
    public int SheetDimensionId { get; set; }
    public string FileExtension { get; set; } = string.Empty;
    public bool IsCmyk { get; set; }
    public float CutMargin { get; set; }
    public float PrintMargin { get; set; }
    public bool IsCheckFile { get; set; }
}
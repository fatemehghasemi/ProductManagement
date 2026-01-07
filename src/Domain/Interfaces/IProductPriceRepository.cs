using Domain.Entities;

namespace Domain.Interfaces;

public interface IProductPriceRepository : IBaseRepository<ProductPrice, int>
{
    Task<IEnumerable<ProductPrice>> GetByProductSizeIdAsync(int productSizeId);
    Task<IEnumerable<ProductPrice>> GetByProductMaterialIdAsync(int productMaterialId);
}
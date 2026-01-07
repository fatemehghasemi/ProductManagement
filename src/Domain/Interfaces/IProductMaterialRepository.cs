using Domain.Entities;

namespace Domain.Interfaces;

public interface IProductMaterialRepository : IBaseRepository<ProductMaterial, int>
{
    Task<IEnumerable<ProductMaterial>> GetByProductIdAsync(int productId);
}
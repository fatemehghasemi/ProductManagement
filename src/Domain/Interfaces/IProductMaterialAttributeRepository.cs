using Domain.Entities;

namespace Domain.Interfaces;

public interface IProductMaterialAttributeRepository : IBaseRepository<ProductMaterialAttribute, int>
{
    Task<IEnumerable<ProductMaterialAttribute>> GetByProductMaterialIdAsync(int productMaterialId);
}
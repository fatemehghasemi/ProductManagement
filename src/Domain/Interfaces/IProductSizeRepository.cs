using Domain.Entities;

namespace Domain.Interfaces;

public interface IProductSizeRepository : IBaseRepository<ProductSize, int>
{
    Task<IEnumerable<ProductSize>> GetByProductIdAsync(int productId);
}
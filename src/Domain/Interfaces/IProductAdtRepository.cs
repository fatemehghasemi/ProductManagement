using Domain.Entities;

namespace Domain.Interfaces;

public interface IProductAdtRepository : IBaseRepository<ProductAdt, int>
{
    Task<IEnumerable<ProductAdt>> GetByProductIdAsync(int productId);
}
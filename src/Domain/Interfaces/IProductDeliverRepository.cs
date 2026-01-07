using Domain.Entities;

namespace Domain.Interfaces;

public interface IProductDeliverRepository : IBaseRepository<ProductDeliver, int>
{
    Task<IEnumerable<ProductDeliver>> GetByProductIdAsync(int productId);
}
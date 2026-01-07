using Domain.Entities;

namespace Domain.Interfaces;

public interface IProductRepository : IBaseRepository<Product, int>
{
    Task<IEnumerable<Product>> GetByProductGroupIdAsync(int productGroupId);
}
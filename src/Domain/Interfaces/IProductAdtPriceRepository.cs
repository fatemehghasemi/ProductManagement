using Domain.Entities;

namespace Domain.Interfaces;

public interface IProductAdtPriceRepository : IBaseRepository<ProductAdtPrice, int>
{
    Task<IEnumerable<ProductAdtPrice>> GetByProductAdtIdAsync(int productAdtId);
}
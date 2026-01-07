using Domain.Entities;

namespace Domain.Interfaces;

public interface IProductAdtTypeRepository : IBaseRepository<ProductAdtType, int>
{
    Task<IEnumerable<ProductAdtType>> GetByProductAdtIdAsync(int productAdtId);
}
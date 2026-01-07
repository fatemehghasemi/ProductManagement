using Domain.Entities;

namespace Domain.Interfaces;

public interface IProductPrintKindRepository : IBaseRepository<ProductPrintKind, int>
{
    Task<IEnumerable<ProductPrintKind>> GetByProductIdAsync(int productId);
}
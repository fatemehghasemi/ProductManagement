using Microsoft.EntityFrameworkCore;
using Domain.Interfaces;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public sealed class ProductPrintKindRepository : BaseRepository<ProductPrintKind, int>, IProductPrintKindRepository
{
    public ProductPrintKindRepository(ProductDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<ProductPrintKind>> GetByProductIdAsync(int productId)
    {
        return await _dbSet
            .Where(ppk => ppk.ProductId == productId)
            .Include(ppk => ppk.Product)
            .ToListAsync();
    }

    public override async Task<IReadOnlyList<ProductPrintKind>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(ppk => ppk.Product)
            .ToListAsync(cancellationToken);
    }

    public override async Task<ProductPrintKind?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(ppk => ppk.Product)
            .FirstOrDefaultAsync(ppk => ppk.Id == id, cancellationToken);
    }
}

using Microsoft.EntityFrameworkCore;
using Domain.Interfaces;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public sealed class ProductAdtRepository : BaseRepository<ProductAdt, int>, IProductAdtRepository
{
    public ProductAdtRepository(ProductDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<ProductAdt>> GetByProductIdAsync(int productId)
    {
        return await _dbSet
            .Where(pa => pa.ProductId == productId)
            .Include(pa => pa.Product)
            .Include(pa => pa.Types)
            .Include(pa => pa.Prices)
            .ToListAsync();
    }

    public override async Task<IReadOnlyList<ProductAdt>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(pa => pa.Product)
            .Include(pa => pa.Types)
            .Include(pa => pa.Prices)
            .ToListAsync(cancellationToken);
    }

    public override async Task<ProductAdt?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(pa => pa.Product)
            .Include(pa => pa.Types)
            .Include(pa => pa.Prices)
            .FirstOrDefaultAsync(pa => pa.Id == id, cancellationToken);
    }
}

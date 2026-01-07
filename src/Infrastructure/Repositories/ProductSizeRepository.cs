using Microsoft.EntityFrameworkCore;
using Domain.Interfaces;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public sealed class ProductSizeRepository : BaseRepository<ProductSize, int>, IProductSizeRepository
{
    public ProductSizeRepository(ProductDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<ProductSize>> GetByProductIdAsync(int productId)
    {
        return await _dbSet
            .Where(ps => ps.ProductId == productId)
            .Include(ps => ps.Product)
            .Include(ps => ps.DeliverSizes)
            .ToListAsync();
    }

    public override async Task<IReadOnlyList<ProductSize>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(ps => ps.Product)
            .Include(ps => ps.DeliverSizes)
            .ToListAsync(cancellationToken);
    }

    public override async Task<ProductSize?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(ps => ps.Product)
            .Include(ps => ps.DeliverSizes)
            .FirstOrDefaultAsync(ps => ps.Id == id, cancellationToken);
    }
}

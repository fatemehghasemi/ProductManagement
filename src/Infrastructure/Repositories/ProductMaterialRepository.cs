using Microsoft.EntityFrameworkCore;
using Domain.Interfaces;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public sealed class ProductMaterialRepository : BaseRepository<ProductMaterial, int>, IProductMaterialRepository
{
    public ProductMaterialRepository(ProductDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<ProductMaterial>> GetByProductIdAsync(int productId)
    {
        return await _dbSet
            .Where(pm => pm.ProductId == productId)
            .Include(pm => pm.Product)
            .Include(pm => pm.Attributes)
            .ToListAsync();
    }

    public override async Task<IReadOnlyList<ProductMaterial>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(pm => pm.Product)
            .Include(pm => pm.Attributes)
            .ToListAsync(cancellationToken);
    }

    public override async Task<ProductMaterial?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(pm => pm.Product)
            .Include(pm => pm.Attributes)
            .FirstOrDefaultAsync(pm => pm.Id == id, cancellationToken);
    }
}

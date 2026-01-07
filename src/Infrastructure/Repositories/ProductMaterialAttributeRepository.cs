using Microsoft.EntityFrameworkCore;
using Domain.Interfaces;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public sealed class ProductMaterialAttributeRepository : BaseRepository<ProductMaterialAttribute, int>, IProductMaterialAttributeRepository
{
    public ProductMaterialAttributeRepository(ProductDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<ProductMaterialAttribute>> GetByProductMaterialIdAsync(int productMaterialId)
    {
        return await _dbSet
            .Where(pma => pma.ProductMaterialId == productMaterialId)
            .Include(pma => pma.ProductMaterial)
            .ToListAsync();
    }

    public override async Task<IReadOnlyList<ProductMaterialAttribute>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(pma => pma.ProductMaterial)
            .ToListAsync(cancellationToken);
    }

    public override async Task<ProductMaterialAttribute?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(pma => pma.ProductMaterial)
            .FirstOrDefaultAsync(pma => pma.Id == id, cancellationToken);
    }
}

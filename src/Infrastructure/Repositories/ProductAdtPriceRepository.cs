using Microsoft.EntityFrameworkCore;
using Domain.Interfaces;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public sealed class ProductAdtPriceRepository : BaseRepository<ProductAdtPrice, int>, IProductAdtPriceRepository
{
    public ProductAdtPriceRepository(ProductDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<ProductAdtPrice>> GetByProductAdtIdAsync(int productAdtId)
    {
        return await _dbSet
            .Where(pap => pap.ProductAdtId == productAdtId)
            .Include(pap => pap.ProductAdt)
            .ToListAsync();
    }

    public override async Task<IReadOnlyList<ProductAdtPrice>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(pap => pap.ProductAdt)
            .ToListAsync(cancellationToken);
    }

    public override async Task<ProductAdtPrice?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(pap => pap.ProductAdt)
            .FirstOrDefaultAsync(pap => pap.Id == id, cancellationToken);
    }
}

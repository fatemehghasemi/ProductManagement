using Microsoft.EntityFrameworkCore;
using Domain.Interfaces;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public sealed class ProductAdtTypeRepository : BaseRepository<ProductAdtType, int>, IProductAdtTypeRepository
{
    public ProductAdtTypeRepository(ProductDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<ProductAdtType>> GetByProductAdtIdAsync(int productAdtId)
    {
        return await _dbSet
            .Where(pat => pat.ProductAdtId == productAdtId)
            .Include(pat => pat.ProductAdt)
            .ToListAsync();
    }

    public override async Task<IReadOnlyList<ProductAdtType>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(pat => pat.ProductAdt)
            .ToListAsync(cancellationToken);
    }

    public override async Task<ProductAdtType?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(pat => pat.ProductAdt)
            .FirstOrDefaultAsync(pat => pat.Id == id, cancellationToken);
    }
}

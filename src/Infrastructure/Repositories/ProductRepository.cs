using Microsoft.EntityFrameworkCore;
using Domain.Interfaces;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public sealed class ProductRepository : BaseRepository<Product, int>, IProductRepository
{
    public ProductRepository(ProductDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Product>> GetByProductGroupIdAsync(int productGroupId)
    {
        return await _dbSet
            .Where(p => p.ProductGroupId == productGroupId)
            .ToListAsync();
    }

    public override async Task<IReadOnlyList<Product>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(p => p.Sizes)
            .Include(p => p.Materials)
            .Include(p => p.Adts)
            .Include(p => p.Delivers)
            .Include(p => p.PrintKinds)
            .ToListAsync(cancellationToken);
    }

    public override async Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(p => p.Sizes)
            .Include(p => p.Materials)
            .Include(p => p.Adts)
            .Include(p => p.Delivers)
            .Include(p => p.PrintKinds)
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }
}

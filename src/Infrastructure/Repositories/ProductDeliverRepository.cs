using Microsoft.EntityFrameworkCore;
using Domain.Interfaces;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public sealed class ProductDeliverRepository : BaseRepository<ProductDeliver, int>, IProductDeliverRepository
{
    public ProductDeliverRepository(ProductDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<ProductDeliver>> GetByProductIdAsync(int productId)
    {
        return await _dbSet
            .Where(pd => pd.ProductId == productId)
            .Include(pd => pd.Product)
            .Include(pd => pd.Sizes)
            .ToListAsync();
    }

    public override async Task<IReadOnlyList<ProductDeliver>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(pd => pd.Product)
            .Include(pd => pd.Sizes)
            .ToListAsync(cancellationToken);
    }

    public override async Task<ProductDeliver?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(pd => pd.Product)
            .Include(pd => pd.Sizes)
            .FirstOrDefaultAsync(pd => pd.Id == id, cancellationToken);
    }
}

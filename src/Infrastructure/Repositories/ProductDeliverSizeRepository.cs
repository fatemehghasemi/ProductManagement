using Microsoft.EntityFrameworkCore;
using Domain.Interfaces;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public sealed class ProductDeliverSizeRepository : BaseRepository<ProductDeliverSize, int>, IProductDeliverSizeRepository
{
    public ProductDeliverSizeRepository(ProductDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<ProductDeliverSize>> GetByProductSizeIdAsync(int productSizeId)
    {
        return await _dbSet
            .Where(pds => pds.ProductSizeId == productSizeId)
            .Include(pds => pds.ProductSize)
            .Include(pds => pds.ProductDeliver)
            .ToListAsync();
    }

    public async Task<IEnumerable<ProductDeliverSize>> GetByProductDeliverIdAsync(int productDeliverId)
    {
        return await _dbSet
            .Where(pds => pds.ProductDeliverId == productDeliverId)
            .Include(pds => pds.ProductSize)
            .Include(pds => pds.ProductDeliver)
            .ToListAsync();
    }

    public override async Task<IReadOnlyList<ProductDeliverSize>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(pds => pds.ProductSize)
            .Include(pds => pds.ProductDeliver)
            .ToListAsync(cancellationToken);
    }

    public override async Task<ProductDeliverSize?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(pds => pds.ProductSize)
            .Include(pds => pds.ProductDeliver)
            .FirstOrDefaultAsync(pds => pds.Id == id, cancellationToken);
    }
}

using Microsoft.EntityFrameworkCore;
using Domain.Interfaces;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public sealed class ProductPriceRepository : BaseRepository<ProductPrice, int>, IProductPriceRepository
{
    public ProductPriceRepository(ProductDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<ProductPrice>> GetByProductSizeIdAsync(int productSizeId)
    {
        return await _dbSet
            .Where(pp => pp.ProductSizeId == productSizeId)
            .Include(pp => pp.ProductSize)
            .Include(pp => pp.ProductMaterial)
            .Include(pp => pp.ProductMaterialAttribute)
            .Include(pp => pp.ProductPrintKind)
            .ToListAsync();
    }

    public async Task<IEnumerable<ProductPrice>> GetByProductMaterialIdAsync(int productMaterialId)
    {
        return await _dbSet
            .Where(pp => pp.ProductMaterialId == productMaterialId)
            .Include(pp => pp.ProductSize)
            .Include(pp => pp.ProductMaterial)
            .Include(pp => pp.ProductMaterialAttribute)
            .Include(pp => pp.ProductPrintKind)
            .ToListAsync();
    }

    public override async Task<IReadOnlyList<ProductPrice>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(pp => pp.ProductSize)
            .Include(pp => pp.ProductMaterial)
            .Include(pp => pp.ProductMaterialAttribute)
            .Include(pp => pp.ProductPrintKind)
            .ToListAsync(cancellationToken);
    }

    public override async Task<ProductPrice?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(pp => pp.ProductSize)
            .Include(pp => pp.ProductMaterial)
            .Include(pp => pp.ProductMaterialAttribute)
            .Include(pp => pp.ProductPrintKind)
            .FirstOrDefaultAsync(pp => pp.Id == id, cancellationToken);
    }
}
